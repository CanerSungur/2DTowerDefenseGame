using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
	//NodeUI objesini tutacak değişken.
	public GameObject ui;

	//UI'daki upgrade miktarını gösteren kısmı tanımlayalım.
	public Text upgradeCost;
	//sell için aynısını yapalım
	public Text sellAmount;

	//Butonu pasif - aktif yapmak için değişkene atayalım
	public Button upgradeButton;

	//Seçilen Node u tutacak olan değişken
	private Node target;

	//BuildManager'da node seçildiğinde bunu çağıracağız.
	public void SetTarget(Node _target)
	{
		//Yani bahsedilen node seçilen node
		target = _target;

		//UI'ın konumunu değiştirelim.
		//target.transform.position demememizin sebebi, pozisyon olarak nodeun merkezini istemiyoruz. Bu merkezi verirdi.
		//target.GetBuildPosition() girerek 0.5 gibi offsetli halini seçmiş oluyoruz. Merkezinden biraz yukarısını pozisyon belirledik yani.
		transform.position = target.GetBuildPosition();

		if (!target.isUpgraded && !target.isUpgradedTwice)//Level 1 ise
		{
			//Level 2 ye atlayacak demektir.
			upgradeCost.text = target.towerBlueprint.GetCostForLevel2().ToString();
			upgradeButton.interactable = true;//butonu açtık

			sellAmount.text = target.towerBlueprint.GetSellValueForLevel1().ToString();
		}
		else if (target.isUpgraded && !target.isUpgradedTwice)//Level 2 ise
		{
			//Level 3 e atlayacak demektir.
			upgradeCost.text = target.towerBlueprint.GetCostForLevel3().ToString();
			upgradeButton.interactable = true;//butonu açtık

			sellAmount.text = target.towerBlueprint.GetSellValueForLevel2().ToString();
		}
		else if (target.isUpgraded && target.isUpgradedTwice)//Level 3 ise
		{
			//Upgrade olamayacak demektir.
			upgradeCost.text = "DONE!";
			upgradeButton.interactable = false;//butonu kapattık.

			sellAmount.text = target.towerBlueprint.GetSellValueForLevel3().ToString();
		}

		//Seçili olduğunda haliyle UI'ı aktif hale getiriyoruz.
		ui.SetActive(true);
	}

	//UI'ı saklayan fonksyion. Yani pasif hale getiriyor.
	//Sadece pasif hale getiriyor. Node'u deselect etmiyor. Yanlış olmasın.
	public void Hide()
	{
		ui.SetActive(false);
	}

	//Upgrade butonunu bağlayacağımız fonksiyon.
	public void Upgrade()
	{
		//Node içindeki upgrade fonksiyonunu çağırdık.
		target.UpgradeTower();

		//Upgrade yaptıktan sonra menünün kapanması gerekiyor.
		//BuildManager'da deselect ettiğimiz gibi burada da aynı fonksiyonu çağırıyoruz.
		BuildManager.instance.DeselectNode();
		//Bu işlem yerine Hide() fonksiyonunu da çağırabilirdik fakat bunu yapsaydık node seçili olmasına rağmen UI'ı gizlemiş olurduk.
		//DeselectNode fonksiyonunu çağırarak node u aynı zamanda deselect etmiş olduk.
	}

	public void Sell()
	{
		//Node içinde yaptığımız fonksiyonu çağırdık.
		target.SellTower();
		//Aynı şekilde sattıktan sonra UI'ı pasif yapıp node u deselect etmemiz lazım.
		BuildManager.instance.DeselectNode();
	}
}
