using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
	BuildManager buildManager;

	//Turret yarattığımızda nodeun içine girmiş duruyor. Bu nedenle offset oluşturacağız.
	public Vector3 positionOffset;

	[HideInInspector]//inspectorda editlenmesini istemiyoruz yani.
					 //node'da turret olup olmadığına dair bilgi tutmamız gerekiyor.
	public GameObject tower;
	[HideInInspector]
	//şuan seçili olan turret blueprinti;
	public TowerBlueprint towerBlueprint;
	//ilk hali yani upgrade edilmemiş durumda;
	[HideInInspector]
	public bool isUpgraded = false;
	[HideInInspector]
	public bool isUpgradedTwice = false;

	//Buradaki Renderer, inspector tarafındaki Mesh Renderer a erişim sağlıyor.
	//Aşağıdaki kodu method içinden alıp buraya koyduk çünkü her hover olduğunda bu işlemi yapacağına bir kez yapıp bilgileri tutmak daha mantıklı.
	private Renderer rend;
	private Color startColor;
	public Color hoverColor;
	public Color notEnoughGoldColor;


	void Start()
	{
		//İşlemi bir kez yaptık. Bundan sonra rend kullanabiliriz.
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	//Başka bir yerde nodea turretı inşa edeceğimiz pozisyonu return aldık.
	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown()
	{
		//Aynı şekilde altta obje varsa bu fonksiyon çaışmayacak. Tıklayıp turret koyamayacağız.
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		//Yani bu nodea birşeyler yapılmışsa eğer
		if (tower != null)
		{
			//Yani buraya tıklandığında turret yoksa, node u seç dedik.
			buildManager.SelectNode(this);
			return;
		}

		//Turret yapılmamışsa eğer yapılabilir mi diye kontrol ediyoruz.
		//Olur da turret yerine null değer yaratmaya çalışırsa alttaki kodlar çalışmasın direk dursun.
		if (!buildManager.CanBuild)
			return;

		//Turret yapılmamışsa ve yapılabiliyorsa eğer turret yap dedik.
		//buildManager.BuildTurretOn(this); Başka script yerine localden fonksiyon yapıp çağırmayı tercih ettik.
		//Parametre olarak doğru blueprint'i girmemiz gerek. Buildmanager'da bunu zaten seçiyorduk. Oradan getirdik.
		BuildTower(buildManager.GetTowerToBuild());
	}

	//Önceden build işlemini BuildManager'dan yapıyorduk fakat,
	//o scriptten Node'a buradan da BuildManager'a referans yapmak yerine buildi burada yapmak daha mantıklı.
	//Build fonksiyonu yapıp OnMouseDown fonksiyonunda çağıralım.(BuildManager'dan çağırmak yerine)
	//BuildMaster'da yazdığımız BuildTurretOn fonksiyonu buraya taşıdık.
	void BuildTower(TowerBlueprint blueprint)
	{
		//Paramız yoksa;
		if (PlayerStats.Gold < blueprint.GetCostToBuild(PlayerStats.costModifier))
		{
			Debug.Log("Not Enough Gold!");
			return;
		}
		//Paramız yetiyosa;
		PlayerStats.Gold -= blueprint.GetCostToBuild(PlayerStats.costModifier);

		//Node içinde turret inşa edecek pozisyonu return eden fonksiyonu çağırarak, prefabi o konumda oluşturduk.
		//Hiç rotate olmamak için Quaternion.identity kullandık.
		GameObject _tower = Instantiate(blueprint.prefabLevel1, GetBuildPosition(), Quaternion.identity);
		//Yani nodedaki turret şuan burada oluşturduğumuz turrettır.
		tower = _tower;

		//turrentBlueprint'in build fonksiyonuna giren blueprint olduğunu belirtmemiz gerekiyor.
		//Bu sayede bu fonksiyona parametre olarak alınan blueprint en başta tanımladığımız ve işlemleri üzerinden yaptığımız turretBlueprint olsun diyoruz.
		towerBlueprint = blueprint;

		//Build effecti yaratalım
		//Rotate olmasın diye Quaternion.identity ekledik.
		//Çıktıktan sonra sahneden silmek için objeye atayıp sonradan sildik.
		//GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		//Destroy(effect, 5f);

		Debug.Log("Tower Build!");
	}

	//Yeni bir turret yapmak ile hemen hemen aynı olacak. O yüzden üstteki kodu kopyalayıp upgrade edilmiş turretı yerleştireceğiz.
	//Üstteki kodu gerekli değiştirmeleri yaparak upgrade fonksiyonunu yaptık.
	//Diğeriyle farkı, upgrade edilen turretı koymak için önce mevcut turretı silmeliyiz.
	public void UpgradeTower()
	{

		if (!isUpgraded && !isUpgradedTwice)//Level 2 yapacagiz.
		{
			if (PlayerStats.Gold < towerBlueprint.GetCostForLevel2())
			{
				Debug.Log("Not Enough Gold!");
				return;
			}

			PlayerStats.Gold -= towerBlueprint.GetCostForLevel2();

			//Eski toweri sildik.
			Destroy(tower);

			//Yeni upgrade edilmiş toweri ekledik.
			GameObject _tower = Instantiate(towerBlueprint.prefabLevel2, GetBuildPosition(), Quaternion.identity);
			tower = _tower;

			//GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
			//Destroy(effect, 5f);

			isUpgraded = true;
			isUpgradedTwice = false;
	
			Debug.Log("Tower Upgraded To Level 2!");
		}

		else if (isUpgraded && !isUpgradedTwice)//Level 3 yapacagiz.
		{
			if (PlayerStats.Gold < towerBlueprint.GetCostForLevel3())
			{
				Debug.Log("Not Enough Gold!");
				return;
			}

			PlayerStats.Gold -= towerBlueprint.GetCostForLevel3();

			//Eski toweri sildik.
			Destroy(tower);

			//Yeni upgrade edilmiş toweri ekledik.
			GameObject _tower = Instantiate(towerBlueprint.prefabLevel3, GetBuildPosition(), Quaternion.identity);
			tower = _tower;

			//GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
			//Destroy(effect, 5f);

			isUpgraded = true;
			isUpgradedTwice = true;

			Debug.Log("Tower Upgraded To Level 3!");
		}
		else
		{
			Debug.Log("Upgrade'de Bir Sorun Olustu!");
		}
	}

	public void SellTower()
	{
		if (!isUpgraded && !isUpgradedTwice)//Level 1 ise
		{
			PlayerStats.Gold += towerBlueprint.GetSellValueForLevel1();
		}
		else if (isUpgraded && !isUpgradedTwice)//Level 2 ise
		{
			PlayerStats.Gold += towerBlueprint.GetSellValueForLevel2();
		}
		else if (isUpgraded && isUpgradedTwice)//Level 3 ise
		{
			PlayerStats.Gold += towerBlueprint.GetSellValueForLevel3();
		}

		//Sell turret efekti;
		//GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		//Destroy(effect, 5f);

		//Sattıktan sonra turretı yokedip, mevcut blueprinti de null yapmamız gerek.
		Destroy(tower);
		towerBlueprint = null;
	}

	//Kullanıcı nodeun üstüne mouseu getirince şunları yap diyelim;
	void OnMouseEnter()
	{
		//UI elementin üstünde miyiz değil miyiz kontrol etmemiz lazım ki altındaki objelerle etkileşime geçemeyelim.
		if (EventSystem.current.IsPointerOverGameObject())//Eğer altta obje varsa hover çalışmasın dedik. 
			return;

		//Yani turret seçmemişsek hover çalışmasın dedik. Sadece yaratmak için turret seçtiğimizde renk değişecek.
		if (!buildManager.CanBuild)
			return;
		//Hover olduğunda rengini değiştirelim.
		//Ama paramız yetiyorsa farklı yetmiyorsa farklı hover rengi olsun
		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		}
		else if (!buildManager.HasMoney)
		{
			rend.material.color = notEnoughGoldColor;
		}

	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
