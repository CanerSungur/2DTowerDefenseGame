using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildNode : MonoBehaviour
{
	BuildManager buildManager;

	[HideInInspector]
	public GameObject tower;
	[HideInInspector]
	public TowerBlueprint towerBlueprint;
	[HideInInspector]
	//public bool isUpgraded = false;

	private Renderer render;
	private Color startColor;
	private Color hoverColor;

	void Start()
	{
		render = GetComponent<Renderer>();
		startColor = render.material.color;
		hoverColor = render.material.color;
		hoverColor.a = 0.8f;

		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position;
	}

	void OnMouseDown()
	{
		buildManager.SelectBuildNode(this);
	}

	void OnMouseEnter()
	{
		render.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		render.material.color = startColor;
	}
}
