using UnityEngine;

public class Menu : MonoBehaviour
{
	public string levelToLoad = "MainLevel";

	//FadeTo'yu kullanmak için değişken oluşturduk.
	public SceneFader sceneFader;

	public void Play()
	{
		//SceneManager.LoadScene(levelToLoad);
		//Buradan direk sonraki sahneyi çağırmak yerine, Faderda düzenlediğimiz FadeTo'yu kullanarak çağıracağız.
		sceneFader.FadeTo(levelToLoad);
	}

	public void Quit()
	{
		Debug.Log("Quitting...");
		Application.Quit();
	}
}
