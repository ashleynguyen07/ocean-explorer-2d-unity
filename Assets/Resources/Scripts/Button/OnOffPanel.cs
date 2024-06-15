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
		Active(shipName);
	}
	void Active(string shipName)
	{
		PlayerPrefs.SetInt("check", 1);
		PlayerPrefs.SetString("tmpShip", shipName);
		if (onOff != true)
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
		
	}
}
