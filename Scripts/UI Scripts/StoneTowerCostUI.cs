using UnityEngine;
using UnityEngine.UI;

public class StoneTowerCostUI : MonoBehaviour
{
	public Shop shop;
	public Text stoneTowerCostText;

	void Update()
	{
		stoneTowerCostText.text = shop.stoneTower.GetCostToBuild(PlayerStats.costModifier).ToString();
	}
}
