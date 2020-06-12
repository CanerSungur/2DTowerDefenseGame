using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	private TowerBlueprint towerToBuild;
	private TowerBlueprint towerToUpgrade;
	private BuildNode selectedBuildNode;
	private TowerNode selectedTowerNode;

	//Build Node
	public GameObject buildNode;
	public BuildNodeUI buildNodeUI;
	public Transform buildNodePosition;
	public Vector3 buildPositionOffset;

	//Tower Node
	public GameObject towerNode;
	public TowerNodeUI towerNodeUI;
	public Transform towerNodePosition;

	//offsetler
	public Vector3 towerPositionOffset;
	public Vector3 towerLevel3PositionOffset;
	public Vector3 deleteTowerOffset;

	[HideInInspector]
	public TowerBlueprint towerBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	//public bool HasMoney { get { return (PlayerStats.Gold >= towerToBuild.costToBuild) || (PlayerStats.Gold >= towerToBuild.costToUpgrade1) || (PlayerStats.Gold >= towerToBuild.costToUpgrade2); } }

	public void BuildTower(TowerBlueprint blueprint)
	{
		Destroy(GameObject.FindGameObjectWithTag("SelectedBuildNode"));

		towerBlueprint = blueprint;
		Instantiate(towerBlueprint.prefab, buildNodePosition.transform.position + buildPositionOffset, Quaternion.identity);
		buildNodeUI.HideUI();
	}

	public void SelectBuildNode(BuildNode node)
	{
		if (selectedBuildNode == node)
		{
			selectedBuildNode.tag = "NotSelectedBuildNode";

			DeselectBuildNode();
			return;
		}
		else if (selectedBuildNode == null)
		{
			buildNodeUI.ShowUI();
			selectedBuildNode = node;
			buildNodePosition = node.transform;

			selectedBuildNode.tag = "SelectedBuildNode";
			Debug.Log("Selected Node");

			//UI'ı seçili node a taşıdık.
			buildNodeUI.SetTarget(node);
		}
		else
			Debug.Log("PROBLEM!!");
	}

	public void DeselectBuildNode()
	{
		buildNodeUI.HideUI();
		selectedBuildNode = null;
		buildNodePosition = null;

		Debug.Log("Deselected Node");
	}

	public void SelectTowerToBuild(TowerBlueprint tower)
	{
		towerToBuild = tower;
	}

	public TowerBlueprint GetTowerToBuild()
	{
		return towerToBuild;
	}

	//#################### UPGRADE ###################
	public void UpgradeTowerToLevel2()
	{
		Destroy(GameObject.FindGameObjectWithTag("SelectedTowerNode"));
		Instantiate(towerBlueprint.upgradedPrefab1, towerNodePosition.transform.position + towerPositionOffset, Quaternion.identity);
		towerNodeUI.HideUI();
	}
	public void UpgradeTowerToLevel3()
	{
		Destroy(GameObject.FindGameObjectWithTag("SelectedTowerNode"));
		Instantiate(towerBlueprint.upgradedPrefab2, towerNodePosition.transform.position + towerPositionOffset, Quaternion.identity);
		towerNodeUI.HideUI();
	}

	public void SelectTowerNode(TowerNode towerNode)
	{
		if (selectedTowerNode == towerNode)
		{
			selectedTowerNode.tag = "NotSelectedTowerNode";

			DeselectTowerNode();
			return;
		}
		else if (selectedTowerNode == null)
		{
			towerNodeUI.ShowUI();
			selectedTowerNode = towerNode;
			towerNodePosition = towerNode.transform;

			selectedTowerNode.tag = "SelectedTowerNode";
			Debug.Log("Selected Tower");

			//UI'ı seçili node a taşıdık.
			towerNodeUI.SetTarget(towerNode);
		}
		else
			Debug.Log("PROBLEM!!");
	}

	public void DeselectTowerNode()
	{
		towerNodeUI.HideUI();
		selectedTowerNode = null;
		towerNodePosition = null;

		Debug.Log("Deselected Tower");
	}

	public void SelectTowerToUpgrade(TowerBlueprint _towerToUpgrade)
	{
		towerToUpgrade = _towerToUpgrade;
	}

	public TowerBlueprint GetTowerToUpgrade()
	{
		return towerToUpgrade;
	}

	public void DeleteTower()
	{
		Destroy(GameObject.FindGameObjectWithTag("SelectedTowerNode"));
		Instantiate(buildNode, towerNodePosition.transform.position + deleteTowerOffset, Quaternion.identity);
		towerNodeUI.HideUI();
	}
}
