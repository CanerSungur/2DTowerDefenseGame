using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public TowerBlueprint arrowTower;
	public TowerBlueprint stoneTower;
	public TowerBlueprint magicTower;
	private TowerBlueprint selectedTower;

	public bool isTowerSelected = false;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectArrowTower()
	{
		buildManager.SelectTowerToBuild(arrowTower);
		Debug.Log("Arrow Tower Selected");
		isTowerSelected = true;
		selectedTower = arrowTower;
		selectedTower.isUpgraded = false;
		selectedTower.isFullyUpgraded = false;
	}

	public void SelectStoneTower()
	{
		buildManager.SelectTowerToBuild(stoneTower);
		Debug.Log("Stone Tower Selected");
		isTowerSelected = true;
		selectedTower = stoneTower;
		selectedTower.isUpgraded = false;
		selectedTower.isFullyUpgraded = false;
	}

	public void SelectMagicTower()
	{
		buildManager.SelectTowerToBuild(magicTower);
		Debug.Log("Magic Tower Selected");
		isTowerSelected = true;
		selectedTower = magicTower;
		selectedTower.isUpgraded = false;
		selectedTower.isFullyUpgraded = false;
	}

	public void BuildSelectedTower()
	{
		if (isTowerSelected)
		{
			if (PlayerStats.Gold < selectedTower.costToBuild)
			{
				Debug.Log("Not Enough Gold!");
				return;
			}
			else if (PlayerStats.Gold >= selectedTower.costToBuild)
			{
				PlayerStats.Gold -= selectedTower.costToBuild;

				buildManager.BuildTower(buildManager.GetTowerToBuild());
				Debug.Log(selectedTower.towerName + " Build!");
			}
			else
			{
				Debug.Log("BİR SORUN OLUŞTU!");
			}
		}
		else
		{
			Debug.Log("Choose A Tower To Build");
		}
		isTowerSelected = false;
	}

	public void UpgradeSelectedTower()
	{
		if (!selectedTower.isUpgraded && !selectedTower.isFullyUpgraded)//Level 1 Kule ise
		{
			if (PlayerStats.Gold < selectedTower.costToUpgrade1)
			{
				Debug.Log("Not Enough Gold!");
				return;
			}
			else if (PlayerStats.Gold >= selectedTower.costToUpgrade1)
			{
				PlayerStats.Gold -= selectedTower.costToUpgrade1;

				buildManager.UpgradeTowerToLevel2();
				selectedTower.isUpgraded = true;
				selectedTower.isFullyUpgraded = false;
				Debug.Log(selectedTower.towerName + " Is Upgraded To Level 2.");
			}
			else
			{
				Debug.Log("BİR SORUN OLUŞTU.");
			}
		}
		else if (selectedTower.isUpgraded && !selectedTower.isFullyUpgraded)//Level 2 Kule ise
		{
			if (PlayerStats.Gold < selectedTower.costToUpgrade2)
			{
				Debug.Log("Not Enough Gold!");
				return;
			}
			else if (PlayerStats.Gold >= selectedTower.costToUpgrade2)
			{
				PlayerStats.Gold -= selectedTower.costToUpgrade2;

				buildManager.UpgradeTowerToLevel3();
				selectedTower.isUpgraded = true;
				selectedTower.isFullyUpgraded = true;

				Debug.Log(selectedTower.towerName + " Is Fully Upgraded.");
			}
			else
			{
				Debug.Log("BİR SORUN OLUŞTU.");
			}
		}
	}

	public void DeleteSelectedTower()
	{
		buildManager.DeleteTower();

		if (!selectedTower.isUpgraded && !selectedTower.isFullyUpgraded)//Level 1 Kule
		{
			PlayerStats.Gold += selectedTower.costToBuild;
		}
		else if (selectedTower.isUpgraded && !selectedTower.isFullyUpgraded)//Level 2 Kule
		{
			PlayerStats.Gold += selectedTower.costToUpgrade1;
		}
		else if (selectedTower.isUpgraded && selectedTower.isFullyUpgraded)//Level 3 Kule
		{
			PlayerStats.Gold += selectedTower.costToUpgrade2;
		}

		selectedTower.isUpgraded = false;
		selectedTower.isFullyUpgraded = false;
		
		Debug.Log(selectedTower.towerName + " IS SOLD!");
	}
}
