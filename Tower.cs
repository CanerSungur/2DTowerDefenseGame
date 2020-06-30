using UnityEngine;

public class Tower : MonoBehaviour
{
	//İlk önce hedefi bulmamız gerekiyor. Bunun için hedefi bir değişkende tutmamız lazım.
	private Transform target;

	[Header("Generals")]
	//turretın range ini de ayarlamamız gerekiyor.
	public float range = 15f;

	[Header("Projectile")]
	public GameObject projectilePrefab;
	//Ateş etmeyi de ekleyelim. Wave spawndaki gibi bir rate değeri, bir de sayaç koyarak yapılıyor.
	public float fireRate = 1f;//Saniyede 1 ateş edecek.
	private float fireCountdown = 0f;//Sayaç. 0 olduğunda ateş edeceğiz.

	[Header("Unity Setup Fields")]
	public string enemyTag = "Enemy";

	//Gorunmez bir objemiz dusmani takip edecek.
	public Transform partToRotate;
	//public float turnSpeed = 10f;
	public Transform firePoint;
	public Vector3 firePointOffset;

	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	//Bu fonksiyon ile tagi enemy olan objeler arasından kendine en yakın olanı bulup onu yeni target yapmasını sağlayacağız.
	//Ayrıca bu fonksiyonu her saniye değil 2-3 saniyede bir çağıracağız.
	//Bu fonksiyonu Start fonksiyonun içinde başlangıçta çağırmamız gerek.
	void UpdateTarget()
	{
		//Hedefler arasında gezinip en yakınını bulmamız lazım. Bunun için Enemy objelerinden oluşan bir array yapmamız gerek.
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

		float shortestDistance = Mathf.Infinity;//Default olarak düşmanla aradaki değer sonsuz uzaklıkta dedik.
		GameObject nearestEnemy = null;

		//Her objede gezerek hepsinin kendisine mesafesine bakacağız. En kısa mesafedeki yeni targetimiz olacak.
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		//Bir düşman var ve bu range'imiz içinde ise
		if (nearestEnemy != null && shortestDistance <= range)
			//Düşman atamasını yapmış olduk. Yani artık hedef, en yakındaki düşmanın koordinatları dedik.
			target = nearestEnemy.transform;
		else
			//rangeden çıktığında targetten de çıkması lazım.
			target = null;
	}

	//Bu fonksiyonda da targetimiz olana kadar hiçbişey yapmamamızı söylememiz lazım.
	void Update()
	{
		//target yoksa kodları çalıştırma.
		if (target == null)
			return;

		LockOnTarget();

		//Ates etmeyi ekleyelim.
		if (fireCountdown <= 0f)//Ateşe hazırsa
		{
			Shoot();
			//fireRate ne kadar yukselirse o kadar kisa surede ates eder.
			fireCountdown = 1f / GetFireRate(PlayerStats.fireRateModifier);
		}
		//Her saniye sayacımız 1'er azalacak. 
		fireCountdown -= Time.deltaTime;
	}

	void LockOnTarget()
	{
		//Şimdi de turreti targete rotate etmemiz lazım. 
		//Basit olarak düşmanın yerini gösteren bir vector3 yapmamız lazım.
		Vector2 direction = target.position - transform.position;
		//Aradaki mesafenin rotasyon değeri
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		//target rotasyonu ile tower rotasyonunu eşitle
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime).eulerAngles;
		//hedefin bilgilerini bir vector3 e atadık. Sonra bunu da turretın rotasyon bilgilerine atayacağız.
		//Turret sadece Z yönünde rotasyona uğrayacağı için diğer değerleri 0f girdik.

		partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);
	}

	void Shoot()
	{
		//projectilePrefab objectini projectile in çıkacağı pozisyon ve rotasyonda yarat dedik.
		GameObject projectileGameObject = Instantiate(projectilePrefab, firePoint.position + firePointOffset, firePoint.rotation);
		//Mermi scriptinden obje oluşturup oradaki hedefi bulan fonksiyonu çağıracağız.
		Projectile projectile = projectileGameObject.GetComponent<Projectile>();

		if (projectile != null)
		{
			projectile.SeekTarget(target);
		}
	}

	//Scene icerisinde range i gormek icin bu fonksiyonu kullaniyoruz.
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

	private float GetFireRate(int fireRateBoost)
	{
		fireRateBoost = PlayerStats.fireRateModifier;
		return fireRate + ((fireRate * fireRateBoost) / 100);
	}
}
