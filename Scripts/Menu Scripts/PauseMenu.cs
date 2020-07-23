using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject ui;

	public SceneFader sceneFader;

	public string menuSceneName = "MainMenu";
	public string gameSceneName = "MainLevel";

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			Toggle();
		}
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

	public void Retry()
	{
		//PauseMenu'den Retry derse player, unity kendisi oyun çalışma hızını 1 e çekmeyecektir. Bunu da eklemek zorundayız ya da direk Toggle fonksiyonunu çağırabiliriz.
		Toggle();

		sceneFader.FadeTo(gameSceneName);
	}

	public void Menu()
	{
		Toggle();
		sceneFader.FadeTo(menuSceneName);
	}
}
