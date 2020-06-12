using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverColorChanger : MonoBehaviour
{
	private Renderer render;
	private Color startColor;
	private Color hoverColor;

	void Start()
	{
		render = GetComponent<Renderer>();
		//childRender = GetComponentInChildren<Renderer>();
		startColor = render.material.color;
		hoverColor = Color.gray;
		hoverColor.a = 0.9f;
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
