using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPower : MonoBehaviour
{
	float power;
	[SerializeField]
	PMove player;
	
	public Power powerObject;
	private void Update()
	{
		power = PlayerPrefs.GetFloat("Power",0f); 
	}
	
	public void CheckClick()
	{
		if (power == 100)
		{
			ClickPower();
		}
		
		
	} 
	void ClickPower()
	{
		powerObject.UpdatePower(0, 100);
		string shipName = "player_extra_00";
		player.Ship(shipName);
		
	}
}
