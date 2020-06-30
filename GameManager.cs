using UnityEngine;

public class GameManager : MonoBehaviour
{
	//Oyunun bitişine göre global ayarlar yapmak için public static bir bool yarattık.
	//Static olduğu için bu oyunun en başında false değerini alacak, player bir kere game over olduğu zaman oyunda true değeri taşımaya başlayacak.
	//Bu sebeple bu değeri her yeni oyun başlattığımızda ya da retry yaptığımızda false değerini aldıracak bir fonksiyon yapacağız.
	public static bool GameIsOver;

	//GameOver objectini player game over olunca aktif edeceğiz.(Şuan pasif) Bu nedenle GameOver objectini buradan oluşturduk. Unity'den içine sürükleyeceğiz.
	//GameOver objectini buradan aktif ve pasif yapacağız.
	//GameOver olunca CameraController scriptini de kapattık. 
	public GameObject gameOverUI;

	public SceneFader sceneFader;

	void Start()
	{
		//Her başladığında değeri false atadık. Static değerlerde buna dikkat et.
		GameIsOver = false;
	}

	void Update()
	{
		//Oyun bitmiş olursa fonksiyonu tekrar tekrar değil bir kere çağırsın diye bunu yaptık.
		if (GameIsOver)
		{
			return;
		}

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	private void EndGame()
	{
		GameIsOver = true;

		//Yani oyun bittiği zaman GameOver objesini aktif yaptık.
		gameOverUI.SetActive(true);
	}
}
