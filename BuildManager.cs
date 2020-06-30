using UnityEngine;

public class BuildManager : MonoBehaviour
{
	//Tüm classlar tarafından erişilmesi için static BuildManager kopyası yapıyoruz.
	//Yani bu aslında burada yazdığımız BuildManager'ı içinde tutacak ve başka yerlerden referans olmadan erişebileceğiz.
	public static BuildManager instance;

	//Bu fonksiyonu yaparak, buradaki BuildManager içinde yaptığımız herşeyi yukarda tanımladığımız değişkene at dedik.
	//Aslında bu değişken burada oluşturduğumuz BuildManager'dır dedik.
	void Awake()
	{
		//Bu instancedan sadece 1 tane olabilir. Eğer bir şekilde daha önceden atandıysa hata vermesini isteyelim.
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	//Effect için prefableri tanımlayalım
	//public GameObject buildEffect;
	//public GameObject sellEffect;

	//Yaratılacak olan turretı tutacak değişken;
	private TowerBlueprint towerToBuild;
	//Upgrade, delete, build işlemleri için işlemin yapılacağı nodeu da seçmemiz gerek.
	private Node selectedNode;

	//UI'ın değişkenini yapalım
	public NodeUI nodeUI;

	//Bu bir property. Sadece bu değişkenden istediğimiz birşeyi return ediyoruz. Birşey set edemeyiz burada.
	public bool CanBuild { get { return towerToBuild != null; } }
	//Yani yeterli paramız varsa true, az paramız varsa false değer alacağız.
	public bool HasMoney { get { return PlayerStats.Gold >= towerToBuild.GetCostToBuild(PlayerStats.costModifier); } }

	//Node seçtiğimiz fonksiyon
	public void SelectNode(Node node)
	{
		//Yani node zaten seçiliyken seçersek deselect etsin.
		if (selectedNode == node)
		{
			DeselectNode();
			return;//alttaki kodları çalıştırma.
		}

		selectedNode = node;
		//Ya yeni bir turret seçicez ya da node u seçip oradaki turreta işlemler yapacağız. Bu nedenle birisini seçince diğerini iptal etmemiz gerek.
		towerToBuild = null;

		//Node seçildiğinde UI çağırılacak
		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		//Seçili nodeu null yaptık ve UI'ı gizledik.
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTowerToBuild(TowerBlueprint tower)
	{
		towerToBuild = tower;
		selectedNode = null;//Node seçiliyse bu iptal edildi. Yukarıda da node seçilince burası iptal edildi.

		//Yani ya node ya turret seçiyorduk. Turret seçtiğimizde Node için yaptığımız UI'ı saklamış olduk.
		nodeUI.Hide();
	}

	//Build edeceğimiz turretı burada seçtirmiştik bunu bir fonksiyon aracıyla Node'da kullandığmız build fonksiyonuna parametre olarak işleyeceğiz.
	//Bu nedenle turretToBuild değişkenini return eden bir fonksiyon yazıp Node scriptinde parametre olarka kullandık.
	public TowerBlueprint GetTowerToBuild()
	{
		return towerToBuild;
	}
}
