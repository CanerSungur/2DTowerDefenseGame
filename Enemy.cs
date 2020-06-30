using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float startSpeed = 2f;
	[HideInInspector]public float speed;

	public float startHealth = 100;
	private float health;

	public int value = 50;
	public int experienceValue;

	//Dusman olunce gerceklesecek efekt
	//public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead = false;

	//Gideceği hedefi tanımlayalım
	private Transform target;
	//Array yapıp 0'dan başlatmıştık. Burada da 0 index değeri tanımlayıp array içine sokacağız.
	//İlk waypoint değeri belirlemek için index 0 yaptık.
	private int waypointIndex = 0;

	void Start()
	{
		//Oyunun başında düşmanımızın hedefini Waypoints'te static belirlediğimiz arraydeki waypointe eşitleyelim ki hedefi o olsun.
		//Static olduğu için Waypoints.points şeklinde direk erişebildik.
		target = Waypoints.points[0];
		health = startHealth;
		speed = startSpeed;
	}

	public void TakeDamage(float damageAmount)
	{
		health -= damageAmount;

		//Image olarak attığımız WhiteSquare tarafında fillAmount kısmını değiştireceğiz.
		//Ama fillAmount 0 ile 1 arasında olduğu için health değerini ona göre ayarlamamız gerekli.
		//Bu değerleri alabilmemiz için scriptin en başına startHealth ve currentHealth ekledik.
		//Bu işlemi yaparak health değerini 0 ve 1 arasında bir değer olarak almış olduk.
		healthBar.fillAmount = health / startHealth;

		if (health <= 0f && !isDead)
		{
			Die();
		}
	}

	public void Slow(float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die()
	{
		isDead = true;

		PlayerStats.Gold += value;

		//GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		//Destroy(effect, 5f);

		//Her düşman öldüğünde hayattaki düşman deişkenini 1 azaltacağız.
		WaveSpawner.EnemiesAlive--;
		Debug.Log("EnemiesAlive: " + WaveSpawner.EnemiesAlive);

		PlayerStats.PlayerExperience += experienceValue;
		Debug.Log("+" + experienceValue + " XP!");
		Destroy(gameObject);
	}

	void Update()
	{
		//Her frame işlediğinde düşmanımızı target e daha da yaklaştırmak istiyoruz.
		//Hedefe gitmemiz için gereken koordinatları girelim.
		//Yani gitmemiz gereken yolu hedefin bulunduğu yerden şuan düşmanın bulunduğu yeri çıkararak buluyoruz. Bu mesafe katedilecek.
		Vector3 direction = target.position - transform.position;

		//Bu şekilde hareketi sağlayalım;
		//Işınlanmadan gitmesi için normalized dedik ve 1 hızında gitmesini sağladık. İstediğimz hızda gitsin diye speed ile çarptık
		//Update fonksiyonunun içinde olduğumuz için Time.deltaTime ile çarpmamız gerekti.
		//Hareketin dünya koordinatlarına göre yapılmasını sağladık. Diğer değer unity içindeki lokal koordinat sistemine göre hareket ettirmektir.
		transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

		//Diğer waypointlere erişince ne olacağını yazalım.
		//Diğer waypointe 0.4f kadar mesafedeyse sonraki waypointe varmıştır kabul edeceğiz.
		//Bunun için şuan bulunduğumuz yer ile target arasındaki mesafe 0.4f e eşit ya da daha küçük olursa varmışız diyeceğiz.
		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			//erişmişiz demektir.
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		//wavepointIndex'imiz eğer tanımlanan point sayısından fazla ya da eşit olursa, en son pointe gelmiş demektir ve yok etmemiz gerekiyor.
		if (waypointIndex >= Waypoints.points.Length - 1)//Yani 13 elemanlı arrayse index 12 olursa. 
		{
			EndPath();
			return;
		}

		//Sonraki waypointe geçmemiz için indexi bir arttırdık;
		waypointIndex++;

		//En başta hep 0'dan başlayacağımız için 0 demiştik. Bundan sonra eriştikçe sonraki pointe doğru gidecek.
		target = Waypoints.points[waypointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;

		//Düşman yolun sonuna erişince de haritadaki hayatta olan düşman sayısını azaltmamız gerek.
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
