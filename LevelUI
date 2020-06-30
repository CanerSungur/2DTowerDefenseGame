using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
	public PlayerStats playerStats;

	public Text expText;
	public Image expBar;

	void Update()
	{
		expText.text = "Level: " + PlayerStats.PlayerLevel;
		expBar.fillAmount =	PlayerStats.PlayerExperience / PlayerStats.ExperienceRequired;
	}
}
