using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerPersistence
{
    public static PlayerData LoadData()
	{
		//Datalari Cektik
		int playerLevel = PlayerPrefs.GetInt("playerLevel");
		float playerExperience = PlayerPrefs.GetFloat("playerExperience");
		float experienceRequired = PlayerPrefs.GetFloat("experienceRequired");
		int attributePoint = PlayerPrefs.GetInt("attributePoint");
		int costAttributePoint = PlayerPrefs.GetInt("costAttributePoint");
		int fireRateAttributePoint = PlayerPrefs.GetInt("fireRateAttributePoint");
		int projectileDamageAttributePoint = PlayerPrefs.GetInt("projectileDamageAttributePoint");
		int costModifier = PlayerPrefs.GetInt("costModifier");
		int fireRateModifier = PlayerPrefs.GetInt("fireRateModifier");
		int projectileDamageModifier = PlayerPrefs.GetInt("projectileDamageModifier");

		PlayerData playerData = new PlayerData()
		{
			//Cektigimiz Datadan yeni degiskenleri olusturduk.
			PlayerLevel = playerLevel,
			PlayerExperience = playerExperience,
			ExperienceRequired = experienceRequired,
			AttributePoint = attributePoint,
			CostAttributePoint = costAttributePoint,
			FireRateAttributePoint = fireRateAttributePoint,
			ProjectileDamageAttributePoint = projectileDamageAttributePoint,
			CostModifier = costModifier,
			FireRateModifier = fireRateModifier,
			ProjectileDamageModifier = projectileDamageModifier

		};

		return playerData;
	}

	public static void SaveData(PlayerStats playerStats)
	{
		//Datayi cektigimiz yere yukluyoruz.
		PlayerPrefs.SetInt("playerLevel", PlayerStats.PlayerLevel);
		PlayerPrefs.SetFloat("playerExperience", PlayerStats.PlayerExperience);
		PlayerPrefs.SetFloat("experienceRequired", PlayerStats.ExperienceRequired);
		PlayerPrefs.SetInt("attributePoint", PlayerStats.PlayerAttributePoints);
		PlayerPrefs.SetInt("costAttributePoint", PlayerStats.costModifierPoint);
		PlayerPrefs.SetInt("fireRateAttributePoint", PlayerStats.fireRateModifierPoint);
		PlayerPrefs.SetInt("projectileDamageAttributePoint", PlayerStats.projectileModifierPoint);
		PlayerPrefs.SetInt("costModifier", PlayerStats.costModifier);
		PlayerPrefs.SetInt("fireRateModifier", PlayerStats.fireRateModifier);
		PlayerPrefs.SetInt("projectileDamageModifier", PlayerStats.projectileModifier);
	}

	public static void DeleteAll()
	{
		//PlayerPrefs.DeleteAll();
		PlayerStats.PlayerLevel = 1;
		PlayerStats.PlayerExperience = 1;
		PlayerStats.ExperienceRequired = 100 * PlayerStats.PlayerLevel * Mathf.Pow(PlayerStats.PlayerLevel, 1f); ;
		PlayerStats.PlayerAttributePoints = 0;
		PlayerStats.costModifierPoint = 0;
		PlayerStats.fireRateModifierPoint = 0;
		PlayerStats.projectileModifierPoint = 0;
		PlayerStats.costModifier = 0;
		PlayerStats.fireRateModifier = 0;
		PlayerStats.projectileModifier = 0;

		SceneManager.LoadScene("MainMenu");
	}
}
