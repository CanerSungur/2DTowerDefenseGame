using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{
	public GameObject ui;

	public Text infoText;
	public Text infoPanelText;

	private List<string> infoList;
	private List<string> infoPanelList;
	private int infoListIndex = 0;

	public float countdown;

	void Start()
	{
		infoList = new List<string>();
		infoList.Add(" - First select a tower to build\n - Then click on one of the holes\n - To upgrade tower, click on a tower\n");
		infoList.Add(" - All tower have 3 levels\n - You can sell towers and change tactic anytime\n");
		infoList.Add(" - Stone towers do 'Area of Effect' damage\n - Magic towers 'Slow' the enemies\n");
		infoList.Add(" - Enemies come from any road available on map\n - On round 5, one of the road blocks blows up\n - On round 10, other road block blows up\n");
		infoList.Add(" - You can pause game by pressing 'ESC', 'P' button or 'House' icon on the right most side of the screen\n");
		infoList.Add(" - Game is always saved when you quit\n - You don't have to Save or Load the game\n - If you want to reset your level and stat progress, you can do it in Stat Menu");

		infoPanelList = new List<string>();
		infoPanelList.Add("You gain attribute points when you level up");
		infoPanelList.Add("You can use your attribute points on stats on Stat Points Menu");
		infoPanelList.Add("To build a tower, select a tower from panel and click on one of the holes");
		infoPanelList.Add("You can pause game by clicking HOUSE BUTTON from right most corner of the screen");
		infoPanelList.Add("You can click INFO BUTTON to read 'How To Play This Game'");
		infoPanelList.Add("You gain experience points from every monster you kill");
		infoPanelList.Add("Road blocks blow up when it's time come");
		infoPanelList.Add("Beware of 3 roads on the map. Enemies can come from any of the road");
		infoPanelList.Add("There are 3 stats you can have. You can check them from Main Menu");
		infoPanelList.Add("All level and stat progress you make is saved automaticly when you quit");
		infoPanelList.Add("If you want to reset all your progress. Go to Stat Points Menu");
		infoPanelList.Add("You can have Lower Tower Cost, Increase Fire Rate or Increase Projectile Damage stats");
		infoPanelList.Add("You can see how much boost you get from stats by checking Stat Menu");
		infoPanelList.Add("Beware! This game has infinite enemy waves");
		infoPanelList.Add("Don't let enemies escape the road. You will lose LIVES");
		infoPanelList.Add("There is no way to gain LIVES during the game session");
		infoPanelList.Add("You should use your 'Attribute Points' after you level up from Stat Menu");
		infoPanelList.Add("You can pause game by pressing 'ESC' or 'P' key");
		infoPanelList.Add("You can access Info Screen by clicking on 'I' button from panel");

		infoText.text = infoList[infoListIndex];
	}

	void Update()
	{
		if (countdown <= 0)
		{
			StartCoroutine(ShowRandomInfo());

			//Wave spawn olduktan sonra sayaci wave arasi belirledigimiz zamana esitledik.
			countdown = 10f;
			return;
		}

		//Saniyede 1 azalt.
		countdown -= Time.deltaTime;
	}

	IEnumerator ShowRandomInfo()
	{
		int randomIndex = Random.Range(0, infoPanelList.Count);
		if (randomIndex == 0)
		{
			infoPanelText.text = infoPanelList[randomIndex];
			randomIndex++;
		}
		else if (randomIndex > 0 && randomIndex < infoPanelList.Count - 1)
		{
			infoPanelText.text = infoPanelList[randomIndex];
			randomIndex++;
		}
		else if (randomIndex == infoPanelList.Count - 1)
		{
			infoPanelText.text = infoPanelList[randomIndex];
			randomIndex = 0;
		}
	
		yield return new WaitForSeconds(5f);
	}

	//Menuyu ac kapa yapacagiz.
	public void Toggle()
	{
		//Yani ui hangi durumdaysa tersine çevirsin dedik.
		ui.SetActive(!ui.activeSelf);

		//Yani PauseMenu UI'ımız aktifse, oyunu pause edeceğiz.
		if (ui.activeSelf)
		{
			//Time.timeScale, oyunun çalışma hızıdır. 1 normal hız, 0 durdurma, 2 iki katı gibi...
			Time.timeScale = 0f;
		}
		else
		{
			//Yani UI pasifse oyun çalışıyor olmalı.
			Time.timeScale = 1f;
		}
	}

	public void ShowNextText()
	{
		if (infoListIndex == infoList.Count - 1)
		{
			infoListIndex = 0;
			infoText.text = infoList[infoListIndex];
		}
		else if (infoListIndex >= 0 && infoListIndex < infoList.Count - 1)
		{
			infoListIndex++;
			infoText.text = infoList[infoListIndex];
		}
	}

	public void ShowPreviousText()
	{
		if (infoListIndex == 0)
		{
			infoListIndex = infoList.Count - 1;
			infoText.text = infoList[infoListIndex];
		}
		else if (infoListIndex >= 0 && infoListIndex < infoList.Count)
		{
			infoListIndex--;
			infoText.text = infoList[infoListIndex];
		}
	}
}
