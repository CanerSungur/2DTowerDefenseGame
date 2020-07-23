using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	//PlayerPrefs icin;
	public PlayerData PlayerData { get; private set; }

	private void OnEnable()
	{
		//Oyun basladiginda Cektigimiz Datalari oyuna sokarak baslattik.

		PlayerData = PlayerPersistence.LoadData();

		PlayerLevel = PlayerData.PlayerLevel;
		PlayerExperience = PlayerData.PlayerExperience;
		PlayerAttributePoints = PlayerData.AttributePoint;
		costModifierPoint = PlayerData.CostAttributePoint;
		fireRateModifierPoint = PlayerData.FireRateAttributePoint;
		projectileModifierPoint = PlayerData.ProjectileDamageAttributePoint;
		costModifier = PlayerData.CostModifier;
		fireRateModifier = PlayerData.FireRateModifier;
		projectileModifier = PlayerData.ProjectileDamageModifier;
	}

	//Oyunu bitirdigimizde Datalari cektigimiz yere atiyoruz.
	private void OnDisable()
	{
		PlayerPersistence.SaveData(this);
	}

	//Bunu calistirirsak tum ilerlememiz siliniyor.
	public void DeleteProgress()
	{
		PlayerPersistence.DeleteAll();
	}
	/* ########################################################################## */

	public static int PlayerLevel;
	public static float PlayerExperience = 1;
	public static float ExperienceRequired;
	public static int PlayerAttributePoints;

	//Harcanacak Perkler
	[HideInInspector]public static int costModifierPoint = 0;
	[HideInInspector]public static int fireRateModifierPoint = 0;
	[HideInInspector]public static int projectileModifierPoint = 0;

	[HideInInspector]public static int costModifier = 0;
	[HideInInspector]public static int fireRateModifier = 0;
	[HideInInspector]public static int projectileModifier = 0;

	private bool isItSuccessfull = false;

	//Playerın kalan canı, parası ile ilgili statlarını burada halledeğiz.
	//Her yerden erişilsin. Her tarafta ayni deger tutsun diye static yaptik.
	public static int Gold;
	public int startGold = 400;

	//canların takibi için;
	public static float Lives;
	public float startLives = 25;

	//GameOver ekranında göstermek için kaç adet Wave bitirmiş onu tutacağız.
	//Mantık olarak her wave spawn olduğunda round 1 artacak. Yani o scriptte 1 ekleme yapabiliriz.
	//Her yerden erişebilmek için static yaptık. Yani start fonksiyonunda default değerini atamalıyız.
	public static int Rounds;

	void Start()
	{
		Gold = startGold;
		Lives = startLives;

		Rounds = 0;//Oyun başladığında sıfırlayalım.
		ExperienceRequired = 100 * PlayerLevel * Mathf.Pow(PlayerLevel, 1f);
	}

	//true donerse basarili false donerse puan yok.
	private void UseAttributePoints()
	{
		if (PlayerAttributePoints > 0)
		{
			PlayerAttributePoints--;
			isItSuccessfull = true;
		}
		else
		{
			Debug.Log("Not Enough Attribute Points!");
			isItSuccessfull = false;
		}
	}

	public void AddDecreaseTowerCostPerk()
	{
		UseAttributePoints();
		if (isItSuccessfull)
		{
			costModifierPoint++;
			costModifier += costModifierPoint;
		}

		//Flagi sifirlamamiz gerekli.
		isItSuccessfull = false;	
	}

	public void AddIncreaseFireRatePerk()
	{
		UseAttributePoints();
		if (isItSuccessfull)
		{
			fireRateModifierPoint++;
			fireRateModifier += (fireRateModifierPoint * 10);
		}

		//Flagi sifirlamamiz gerekli.
		isItSuccessfull = false;
	}
	public void AddIncreaseProjectileDamagePerk()
	{
		UseAttributePoints();
		if (isItSuccessfull)
		{
			projectileModifierPoint++;
			projectileModifier += (projectileModifierPoint * 5);
		}

		//Flagi sifirlamamiz gerekli.
		isItSuccessfull = false;
	}
}
