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
	public void btnOnOffPanel(string comboship)
	{
		Active(comboship);
		
	}

	void Active(string comboship)
	{
		string shipName = "";
		string bulletName = "";
		string childName = "";

		if (comboship.Equals("combo1"))
		{
			shipName = "ship1";
			bulletName = "bulletP1";
			childName = "child1";
		}else if (comboship.Equals("combo2"))
		{
			shipName = "ship2";
			bulletName = "bulletP2";
			childName = "child2";
		}
		else if (comboship.Equals("combo3"))
		{
			shipName = "ship3";
			bulletName = "bulletP3";
			childName = "child3";
		}
		
		
		if (onOff != true&& comboship.Equals("null"))
		{
			onOff = true;
			popupPanel.SetActive(true);
		}
		else if (comboship.Equals("close"))
		{
			onOff = false;
			popupPanel.SetActive(false);
		}
		else
		{
			PlayerPrefs.SetInt("check", 1);
			PlayerPrefs.SetString("tmpShip1", shipName);
			PlayerPrefs.SetString("tmpChild", childName);
			PlayerPrefs.SetString("tmpBullet", bulletName);
			
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

		if (onOffChild != true && child.Equals("null"))
		{
			PlayerPrefs.SetString("tmpChild", "default");
			onOffChild = true;
			popupPanel.SetActive(true);
		}
		else if (child.Equals("close"))
		{
			onOffChild = false;
			popupPanel.SetActive(false);
		}
		else
		{
			PlayerPrefs.SetInt("check", 1);
			PlayerPrefs.SetString("tmpChild", child);
			onOffChild = false;
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

		if (onOffShip != true && shipName.Equals("null"))
		{
			onOffShip = true;
			popupPanel.SetActive(true);
		}
		else
		if (shipName.Equals("close"))
		{
			onOffShip = false;
			popupPanel.SetActive(false);
		}
		else
		{
			PlayerPrefs.SetInt("check", 1);
			PlayerPrefs.SetString("tmpShip1", shipName);
			onOffShip = false;
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
		if (onOffBullet != true && bullet.Equals("null"))
		{
			onOffBullet = true;
			popupPanel.SetActive(true);
		}
		else if (bullet.Equals("close"))
		{
			onOffBullet = false;
			popupPanel.SetActive(false);
		}
		else
		{
			PlayerPrefs.SetInt("check", 1);
			PlayerPrefs.SetString("tmpBullet", bullet);
			onOffBullet = false;
			popupPanel.SetActive(false);
		}

	}

}
