using UnityEngine;

public class Projectile : MonoBehaviour
{
	private Transform target;

	[Header("General Attributes")]
	public float speed = 70f;
	public float damage = 50f;

	[Header("Special Attributes")]
	public float explosionRadius = 0f;
	public float slowRate = 0f;
	private float slowDuration = 1f;
	private float slowCountdown = 0f;
	public bool isSlowing = false;

	[Header("Impact Effect")]
	public GameObject impactEffect;

	//Bu fonksiyonu Turretta Shoot() fonksiyonunda çağıracağız.
	public void SeekTarget(Transform _target)
	{
		target = _target;
	}

	void Update()
	{
		//Hedef yok olduğunda projectile in gitmesi gereken yer de olmayacaktır. Bu nedenle her framede hedefin varolduğuna bakmamız gerek.
		//Hedef yok olursa, o hedefe kitlenen projectile in da yok olmasını sağlamamız lazım.
		if (target == null)
		{
			Destroy(gameObject);
			//Destroy çalıştıktan sonra bunu koymak mantıklı olacaktır. Bazen kod aşağıya doğru akmaya devam edebiliyor.
			return;
		}

		//Hedef noktaya giden yolu belirlemek için hedef nokta ile bulunan noktayı çıkarıp vector3 e atıyoruz.
		Vector3 direction = target.position - transform.position;
		//projectile in kat ettiği yol
		float distanceThisFrame = speed * Time.deltaTime;

		if (direction.magnitude <= distanceThisFrame)
		{
			//Yani gideceğimiz yönün uzunluğu(magnitude) merminin kat ettiği yoldan küçükse birşeye çarptık demektir.
			HitTarget();
			return;
		}

		//Projectile i hareket ettirelim.
		transform.Translate(direction.normalized * distanceThisFrame, Space.World);
		//transform.LookAt(target);

		//Gizmosu bu sekilde oldugundan Z'ye gore hareket sagladik.
		float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
	}

	void HitTarget()
	{
		//merminin bulunduğu pozisyon ve rotasyonda yarat diyelim;
		GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectInstance, .6f);//Efekti 2 saniye sonra destroy ettik.

		//Prefab AOE ayarı
		if (explosionRadius > 0f)//AOE damage gelirse patlama fonksiyonunu çalıştır.
		{
			Explode();	
		}
		if (slowRate > 0f)//Slow yapabilen bir projectile ise
		{
			Slow(target);
		}
		else//Yani AOE damage veya slow gelmezse tek düşmana damage ver.
		{
			Damage(target);
		}
		//Birşeye çarpınca mermiyi yok edelim
		Destroy(gameObject);
	}

	void Explode()
	{
		//İlk olarak safir şeklinde çapını ve konumunu belirlediğimiz alanda nelere çarpıyor bunu alıp bir Collider arrayine atıyoruz.
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		//Bu alandaki tüm objeler içinde gezip tagi enemy olanları seçiyoruz ve onlara damage fonksiyonunu uyguluyoruz.
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Slow(Transform enemy)
	{
		isSlowing = true;

		//Dusman objesi olusturup dusmanin hizini azaltiyoruz.
		Enemy e = enemy.GetComponent<Enemy>();
		if (e != null)
		{
			e.speed = e.startSpeed * (1f - slowRate);
			Damage(target);
		}
	}

	void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		if (e != null)
		{
			e.TakeDamage(GetProjectileDamage(PlayerStats.projectileModifier));
		}
	}

	//Scene icerisinde AOE patlama alanini gormek icin bu fonksiyonu girdik.
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}

	private float GetProjectileDamage(int projectileDamageBoost)
	{
		projectileDamageBoost = PlayerStats.projectileModifier;
		return damage + ((damage * projectileDamageBoost) / 100);
	}
}
