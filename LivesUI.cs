using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
	public PlayerStats playerStats;

	public Text livesText;
	public Image healthBar;

	void Update()
	{
		livesText.text = "Lives: " + PlayerStats.Lives.ToString();
		healthBar.fillAmount = PlayerStats.Lives / playerStats.startLives;
	}
}
