using UnityEngine;
using TMPro;

public class StatChanger : MonoBehaviour
{
	public PlayerStats playerStats;

	public TextMeshProUGUI costPoints;
	public TextMeshProUGUI costModifier;
	public TextMeshProUGUI fireRatePoints;
	public TextMeshProUGUI fireRateModifier;
	public TextMeshProUGUI projectileDamagePoints;
	public TextMeshProUGUI projectileDamageModifier;

	public TextMeshProUGUI attributePoints;

	void Update()
	{
		costModifier.text = "-" + PlayerStats.costModifier + " % Tower Cost";
		fireRateModifier.text = "+" + PlayerStats.fireRateModifier + " % Fire Rate";
		projectileDamageModifier.text = "+" + PlayerStats.projectileModifier + " % Projectile Damage";

		costPoints.text = PlayerStats.costModifierPoint.ToString();
		fireRatePoints.text = PlayerStats.fireRateModifierPoint.ToString();
		projectileDamagePoints.text = PlayerStats.projectileModifierPoint.ToString();

		attributePoints.text = "Remaining Attribute Points: " + PlayerStats.PlayerAttributePoints;
	}

	public void ChangeCost()
	{
		playerStats.AddDecreaseTowerCostPerk();
	}
	public void ChangeFireRate()
	{
		playerStats.AddIncreaseFireRatePerk();
	}
	public void ChangeProjectileDamage()
	{
		playerStats.AddIncreaseProjectileDamagePerk();
	}
}
