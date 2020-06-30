using UnityEngine;

public class GameOver : MonoBehaviour
{
	public SceneFader sceneFader;

	public string menuSceneName = "MainMenu";
	public string gameSceneName = "MainLevel";

	public void Retry()
	{
		//Şuan aktif olan sahneyi tekrar load ettik.
		sceneFader.FadeTo(gameSceneName);
	}

	public void Menu()
	{
		sceneFader.FadeTo(menuSceneName);
	}
}
