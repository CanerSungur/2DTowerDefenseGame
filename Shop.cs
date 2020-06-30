using UnityEngine;

public class Shop : MonoBehaviour
{
	public TowerBlueprint arrowTower;
	public TowerBlueprint stoneTower;
	public TowerBlueprint magicTower;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectArrowTower()
	{
		Debug.Log("Arrow Tower Selected.");
		//Yaratılacak turretı standart turret seçtirdik.
		buildManager.SelectTowerToBuild(arrowTower);
	}

	public void SelectStoneTower()
	{
		Debug.Log("Stone Tower Selected.");
		buildManager.SelectTowerToBuild(stoneTower);
	}

	public void SelectMagicTower()
	{
		Debug.Log("Magic Tower Selected.");
		buildManager.SelectTowerToBuild(magicTower);
	}
}
