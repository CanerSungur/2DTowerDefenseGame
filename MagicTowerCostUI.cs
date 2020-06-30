using UnityEngine;
using UnityEngine.UI;

public class MagicTowerCostUI : MonoBehaviour
{
	public Shop shop;
	public Text magicTowerCostText;

	void Update()
	{
		magicTowerCostText.text = shop.magicTower.GetCostToBuild(PlayerStats.costModifier).ToString();
	}
}
