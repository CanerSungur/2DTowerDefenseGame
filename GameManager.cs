using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static bool GameIsOver;

	//public GameObject gameOverUI;
	//public GameObject completeLevelUI;
	//public SceneFader sceneFader;

	void Start()
	{
		GameIsOver = false;
	}

	void Update()
	{
		if (GameIsOver)
		{
			return;
		}
		else
		{
			if (PlayerStats.Lives <= 0)
			{
				EndGame();
			}
		}
	}

	private void EndGame()
	{
		GameIsOver = true;
		Debug.Log("GAME OVER!");
	}
}
