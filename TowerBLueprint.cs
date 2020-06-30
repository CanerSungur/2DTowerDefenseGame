using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
	//Burayi kullanarak Shop'ta istedigimiz toweri olusturabilecegiz.
	public GameObject prefabLevel1;
	public GameObject prefabLevel2;
	public GameObject prefabLevel3;
	public string towerName;
	private int costBoost = PlayerStats.costModifier;
	public int costToBuild;

	public int GetCostToBuild(int _costBoost)
	{
		_costBoost = PlayerStats.costModifier;
		return (int)(costToBuild - ((costToBuild * costBoost)/100));
	}

	public int GetCostForLevel2()
	{
		int c = GetCostToBuild(costBoost);
		return c += (c * 25) / 100;
	}
	public int GetCostForLevel3()
	{
		int c = GetCostToBuild(costBoost);
		return c += (c * 40) / 100;
	}

	public int GetSellValueForLevel1()
	{
		int c = GetCostToBuild(costBoost);
		return (c * 50) / 100;
	}
	public int GetSellValueForLevel2()
	{
		int c = GetCostToBuild(costBoost);
		return ((c += (c * 25) / 100) * 50) / 100;
	}
	public int GetSellValueForLevel3()
	{
		int c = GetCostToBuild(costBoost);
		return ((c += (c * 40) / 100) * 50) / 100;
	}
}
