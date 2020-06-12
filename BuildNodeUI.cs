using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildNodeUI : MonoBehaviour
{
	public GameObject ui;

	//public Text buildCost;
	//public Text infoText;

	private BuildNode target;

	
	public void SetTarget(BuildNode _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();

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
