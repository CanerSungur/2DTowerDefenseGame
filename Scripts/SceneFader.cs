using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
	//Sahne gecis efektini burasi yapacak.
	//SceneFader kodlamasını bitirdikten sonra bunu kullanabilmemiz için tüm kodlamada sahne çağırdığımız yerleri FadeTo ile çağırmamız gerekecek.

	public Image img;

	//Farklı animasyonlar için Unity farklı özellikler sunuyor.
	public AnimationCurve curve;

	void Start()
	{
		StartCoroutine(FadeIn());
	}

	//Hangi sahneye fade olacağımızı belirleyen fonksiyonu girelim.
	public void FadeTo(string scene)
	{
		StartCoroutine(FadeOut(scene));
	}

	//Fade olayını belirli saniyede çalıştırıp, sahneyi o kadar saniye bekleteceğiz. Bu nedenle Coroutine kullanmak gerekiyor;
	//Sahnenin Fade in olduğu fonksiyonu girelim.
	IEnumerator FadeIn()
	{
		//imagein alpha değerini 1'den 0'a doğru yavaş yavaş indireceğiz. 
		//Bir zaman değişkeni yarattık.
		float t = 1f;

		//Zaman değerimiz 0'dan büyük olduğunca animasyonu oynatmaya devam edeceğiz.
		while (t > 0f)
		{
			//zamanı frame frame düşürdük.
			t -= Time.deltaTime;
			//Yukarıda tanımladığımız curve u kullanarak animasyonun curveunu alpha değişkeni atayıp buraya girdik.
			float a = curve.Evaluate(t);

			//Değer verirken direk olarka Alpha değerini atayamıyoruz. 
			//Bunun yerine rgba olarak renk ataması yapıyoruz. En sonraki alpha değerini girdik.
			//Bu şekilde 1 ile 0 arasında olan saniye değerimiz azaldıkça alpha da azalacak ve siyah ekranımız yavaşça yok olacaktır.
			img.color = new Color(0f, 0f, 0f, a);

			//Aşağıdakinin tam olarak anlamı: 1 frame bekle ve sonra koda devam et.
			yield return 0;
		}

	}

	//Sahnenin fade out olacağı fonksiyonu girelim şimdi de
	//Fade Out yaptığımız zaman hangi sahneye geçeceğini de belirlememiz gerekecek. O nedenle parametre almamız gerekiyor.
	IEnumerator FadeOut(string scene)
	{
		//Tüm değerleri tersten oluşturmamız gerekiyor. Alphayı bu sefer 0'dan 1'e doğru yönlendireceğiz.
		float t = 0f;

		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = curve.Evaluate(t);

			img.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
		//Fade olaylarını bitirdik. Şimdi sonraki sahneyi çağırmamız lazım.
		SceneManager.LoadScene(scene);
	}
}
