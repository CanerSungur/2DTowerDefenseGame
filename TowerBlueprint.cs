using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
	public GameObject prefab;
	public GameObject upgradedPrefab1;
	public GameObject upgradedPrefab2;
	public string towerName;
	public int costToBuild;
	public int costToUpgrade1;
	public int costToUpgrade2;

	public int sellingValue1;
	public int sellingValue2;
	public int sellingValue3;

	public bool isUpgraded;
	public bool isFullyUpgraded;
}
