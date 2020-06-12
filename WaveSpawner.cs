using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;
	public float countdown;
	private int waveNumber = 0;

	public GameManager gameManager;

	void Update()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}
		else if (EnemiesAlive <= 0)
		{
			if (countdown <= 0)
			{
				StartCoroutine(SpawnWave());

				countdown = timeBetweenWaves;
				return;
			}

			countdown -= Time.deltaTime;
			countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
		}
	}

	IEnumerator SpawnWave()
	{
		PlayerStats.Rounds++;
		
		Wave wave = waves[waveNumber];
		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}
		waveNumber++;
	}

	void SpawnEnemy(GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}
}
