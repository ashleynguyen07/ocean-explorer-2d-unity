using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnOffPanel : MonoBehaviour
{
	bool onOff = false;
	bool onOffShip = false;
	bool onOffBullet = false;
	bool onOffChild = false;
	[SerializeField]
	GameObject popupPanel;
	public void btnOnOffPanel(string shipName)
	{
		Active(shipName);
	}

	void Active(string shipName)
	{
		
		if (onOff != true)
		{
			onOff = true;
			popupPanel.SetActive(true);
		}
		else if (shipName.Equals("close"))
		{
			onOff = false;
			popupPanel.SetActive(false);
		}
		else
		{
			PlayerPrefs.SetInt("check", 1);
			PlayerPrefs.SetString("tmpShip", shipName);
			PlayerPrefs.SetString("ShipName", shipName);
			PlayerPrefs.Save();
			onOff = false;
			popupPanel.SetActive(false);
		}

	}
	//===========================================
	public void btnOnOffPanelChild(string child)
	{
		ActiveChild(child);
	}
	void ActiveChild(string child)
	{

		if (onOff != true && child.Equals("null"))
		{
			onOff = true;
			popupPanel.SetActive(true);
		}
		else if (child.Equals("close"))
		{
			onOff = false;
			popupPanel.SetActive(false);
		}
		else
		{
			PlayerPrefs.SetInt("check", 1);
			PlayerPrefs.SetString("tmpChild", child);
			PlayerPrefs.SetString("ChildName", child);
			PlayerPrefs.Save();
			onOff = false;
			popupPanel.SetActive(false);
		}

	}
	//===========================================
	public void btnOnOffPanelShip(string shipName)
	{
		ActiveShip(shipName);
	}
	void ActiveShip(string shipName)
	{

		if (onOff != true && shipName.Equals("null"))
		{
			onOff = true;
			popupPanel.SetActive(true);
		}
		else
		if (shipName.Equals("close"))
		{
			onOff = false;
			popupPanel.SetActive(false);
		}
		else
		{
			PlayerPrefs.SetInt("check", 1);
			PlayerPrefs.SetString("Ship1", shipName);
			PlayerPrefs.SetString("ShipName1", shipName);
			PlayerPrefs.Save();
			onOff = false;
			popupPanel.SetActive(false);
		}

	}
	//=================================
	public void btnOnOffPanelBullet(string bullet)
	{
		ActiveBullet(bullet);
	}
	void ActiveBullet(string bullet)
	{
		if (onOff != true && bullet.Equals("null"))
		{
			onOff = true;
			popupPanel.SetActive(true);
		}
		else if (bullet.Equals("close"))
		{
			onOff = false;
			popupPanel.SetActive(false);
		}
		else
		{
			PlayerPrefs.SetInt("check", 1);
			PlayerPrefs.SetString("tmpBullet", bullet);
			PlayerPrefs.SetString("BulletName", bullet);
			PlayerPrefs.Save();
			onOff = false;
			popupPanel.SetActive(false);
		}

	}

}
