using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public Text livesText;
	public Text goldText;

	public static int Gold;
	public int startGold = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

	void Start()
	{
		Gold = startGold;
		Lives = startLives;
		Rounds = 0;
	}

	void Update()
	{
		livesText.text = "LIVES: " + Lives.ToString();
		goldText.text = "GOLD: " + Gold.ToString();
	}
}
