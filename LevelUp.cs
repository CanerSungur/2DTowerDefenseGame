using UnityEngine;

public class LevelUp : MonoBehaviour
{
	void Update()
	{
		Exp();
	}

	void RankUp()
	{
		PlayerStats.PlayerLevel++;
		PlayerStats.PlayerAttributePoints++;
		PlayerStats.PlayerExperience = 1;

		//internetten buldugumuz karakterin level atlamasi icin gereken expi hesaplama fonksiyonu;
		PlayerStats.ExperienceRequired = 100 * PlayerStats.PlayerLevel * Mathf.Pow(PlayerStats.PlayerLevel, 1f);
		Debug.Log("EXP REQUIRED: " + PlayerStats.ExperienceRequired);

		Debug.Log("You Are Now Level " + PlayerStats.PlayerLevel);
	}

	void Exp()
	{
		if (PlayerStats.PlayerExperience >= PlayerStats.ExperienceRequired)
		{
			RankUp();
		}
	}
}
