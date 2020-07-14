using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
	public WaypointDecider waypointDecider;

	//Kaç düşmanın hayatta olduğunu tutacak değişken
	public static int EnemiesAlive;

	//Tek tek düşman çağırmaktansa, wave classında oluşturduğumuz wave'leri çağırmak daha mantıklı.
	//Wave arrayi oluşturup her elemanını ayrı ayrı customize ettik. Bunu da burada index kullanarak çağıracağız.
	public List<Wave> waves = new List<Wave>();
	//public List<Wave> bossWave = new List<Wave>();


	//Doğacak düşmanı nerede doğuracağımızı belirlemek için;
	public Transform spawnPoint;
	//Düşman dalgaları arasındaki spawn zamanını tanımlayalım.
	public float timeBetweenWaves = 5f;
	//Wave'in spawn olmasında beklenecek olan süreyi tanımlayalım.
	public float countdown;
	//Wave'de kac dusman olacagini belirlemek icin.
	private int waveNumber = 0;

	//Oyun sonu ekrani fonksoyonlarini cagirmak icin olusturduk.
	public GameManager gameManager;
	public Text WaveCountdownText;

	void Start()
	{
		EnemiesAlive = 0;	
	}

	void Update()
	{
		

		//dusmanlarin hepsi olmeden spawn eden alttaki kodlari calistirma dedik.
		if (EnemiesAlive > 0)
		{
			return;
		}

			if (countdown <= 0)
			{
				StartCoroutine(SpawnWave());

				//Wave spawn olduktan sonra sayaci wave arasi belirledigimiz zamana esitledik.
				countdown = timeBetweenWaves;
				return;
			}

		//Saniyede 1 azalt.
		countdown -= Time.deltaTime;

			//countdown in negatif bir deger almamasi icin 0 ile sonsuz arasinda degerler alabilir dedik.
			countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

			//UI'daki sayac bolumunu girelim.
			//Virgullu formatta gostermesini sagladik.
			WaveCountdownText.text = "Countdown: " + string.Format(("{0:00.0}"), countdown);
	}

	//Dusmanlar arasinda bosluk birakmak icin belirli saniyede bir dusman spawn etmemiz lazim. Bunun icin;
	IEnumerator SpawnWave()
	{
		waypointDecider.DecideWaypoint();

		PlayerStats.Rounds++;

		for (int i = 0 ; ; i++)
		{
			Wave wave = waves[i];
			Debug.Log((i + 1) + ". Dalga Olusturuldu.");

			int randomEnemyCount = wave.GetRandomEnemyCount();

			EnemiesAlive = randomEnemyCount;

			if (PlayerStats.Rounds != 0 && PlayerStats.Rounds % 9 == 0)//9 ve katlarinda
			{
				SpawnEnemy(wave.bosses[0]);
				Debug.Log(wave.bosses[0].enemyName + " HAS SPAWNED!");
			}
			if (PlayerStats.Rounds != 0 && PlayerStats.Rounds % 11 == 0)//11 ve katlarinda
			{
				SpawnEnemy(wave.bosses[1]);
				Debug.Log(wave.bosses[1].enemyName + " HAS SPAWNED!");
			}
			if (PlayerStats.Rounds != 0 && PlayerStats.Rounds % 15 == 0)//15 ve katlarinda
			{
				SpawnEnemy(wave.bosses[2]);
				Debug.Log(wave.bosses[2].enemyName + " HAS SPAWNED!");
			}

			for (int j = 0; j < randomEnemyCount; j++)
			{
				SpawnEnemy(wave.enemies[wave.GetRandomEnemyIndex()]);
				yield return new WaitForSeconds(1f / wave.rate);
			}
		}

	}

	void SpawnEnemy(EnemyBlueprint enemyBlueprint)
	{
		Instantiate(enemyBlueprint.enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
