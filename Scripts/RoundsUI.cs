using UnityEngine;
using UnityEngine.UI;

public class RoundsUI : MonoBehaviour
{
	public Text roundsText;

	void Update()
	{
		roundsText.text = "Rounds: " + PlayerStats.Rounds;
	}
}
