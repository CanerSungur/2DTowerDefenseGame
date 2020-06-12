using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNodeUI : MonoBehaviour
{
	public GameObject ui;

	private TowerNode target;

	public void SetTarget(TowerNode _target)
	{
		target = _target;

		transform.position = target.GetTowerPosition();

		//buildCost.text = target.towerBlueprint.costToBuild.ToString();
		//infoText.text = "Arrow tower çok iyi ya...";

		ui.SetActive(true);
	}

	public void HideUI()
	{
		ui.SetActive(false);
	}
	public void ShowUI()
	{
		ui.SetActive(true);
	}
}
