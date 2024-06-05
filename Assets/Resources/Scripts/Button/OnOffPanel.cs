using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffPanel : MonoBehaviour
{
	bool onOff = false;
	[SerializeField]
	 GameObject popupPanel;
	public void btnOnOffPanel(string shipName)
	{
		if (onOff !=true)
		{
			onOff = true;
			popupPanel.SetActive(true);
		}
		else
		{
			PlayerPrefs.SetString("ShipName", shipName);
			PlayerPrefs.Save();
			onOff = false;
			popupPanel.SetActive(false);
		}
		string highScore = PlayerPrefs.GetString("ShipName");
		Debug.Log("Ship name" + highScore);
	}
}
