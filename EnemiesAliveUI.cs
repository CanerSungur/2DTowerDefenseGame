using UnityEngine;
using UnityEngine.UI;

public class EnemiesAliveUI : MonoBehaviour
{
	public Text enemiesAliveText;

	void Update()
	{
		enemiesAliveText.text = "Enemies Alive: " + WaveSpawner.EnemiesAlive;
	}
}
