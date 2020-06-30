using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
	//GameOver scriptine yazdığımız bazı şeyleri buraya taşıdık. Daha iyi kontrol edebilmek ve daha temiz olmasını sağlamak için.

	//GameOver ekranındaki geçilen round kısmını gösterelim.
	public Text roundsText;

	void OnEnable()
	{
		//Object her enabled oldğunda mevcut round sayısını ekrana yazdıracağız.
		//roundsText.text = PlayerStats.Rounds.ToString();
		//Texti direk göstermeyip, animasyon eklediğimiz için üstteki kodlamayı iptal edip gerekli eklemeyi yaptık.
		StartCoroutine(AnimateText());
	}

	IEnumerator AnimateText()
	{
		//0'dan başlayarak geldiğimiz bölüme kadar sayan bir sayaç animasyonu yapacağız.
		roundsText.text = "0";//Yazı 0'dan başlayacak
		int round = 0;

		//UI'ımız fade olarak girdiği için, bu fade olduktan sonra animasyonu oynatmamız lazım. Yani en başta biraz delay eklememiz gerekecek.
		yield return new WaitForSeconds(.07f);

		//Yani burada belirlediğimiz round değişkeni oyuncunun geldiği round sayısına gelene kadar animasyon oynatacağız.
		while (round < PlayerStats.Rounds)
		{
			//Yani başarılan bölüme gelene kadar rounda 1 ekleyip her seferinde ekrandaki textte bunu göstereceğiz.
			round++;
			roundsText.text = round.ToString();

			//Animasyon olması için bu sayıları her gösterdiğinde biraz bekletmemiz gerekiyor ki gözle görülebilsin.
			yield return new WaitForSeconds(.05f);
		}
	}
}
