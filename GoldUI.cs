using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
	public Text goldText;

	void Update()
	{
		goldText.text = PlayerStats.Gold.ToString();
	}
}
