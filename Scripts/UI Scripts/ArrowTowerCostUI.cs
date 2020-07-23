using UnityEngine;
using UnityEngine.UI;

public class ArrowTowerCostUI : MonoBehaviour
{
	public Shop shop;
	public Text arrowTowerCostText;

	void Update()
	{
		arrowTowerCostText.text = shop.arrowTower.GetCostToBuild(PlayerStats.costModifier).ToString();
	}
}
