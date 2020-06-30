using UnityEngine;
using UnityEngine.UI;

public class AttributePointsUI : MonoBehaviour
{
	public Text attributePointsText;

	void Update()
	{
		attributePointsText.text = "Attribute Points: " + PlayerStats.PlayerAttributePoints;
	}
}
