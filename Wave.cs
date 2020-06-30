using UnityEngine;

[System.Serializable]
public class Wave
{
	public EnemyBlueprint[] enemies;
	public EnemyBlueprint[] bosses;

	public int count;
	public float rate;

	public int GetRandomEnemyCount()
	{
		if (PlayerStats.Rounds < 10)
			return Random.Range(5, 15);
		else if (PlayerStats.Rounds >= 10 && PlayerStats.Rounds <= 15)
			return Random.Range(10, 15);
		else if (PlayerStats.Rounds > 15 && PlayerStats.Rounds < 25)
			return Random.Range(15, 20);
		else if (PlayerStats.Rounds >= 25 && PlayerStats.Rounds <= 35)
			return Random.Range(20, 30);
		else if (PlayerStats.Rounds > 35 && PlayerStats.Rounds < 50)
			return Random.Range(30, 40);
		else
			return Random.Range(40, 50);
	}
	public int GetRandomEnemyIndex()
	{
		return Random.Range(0, 6);
	}
}
