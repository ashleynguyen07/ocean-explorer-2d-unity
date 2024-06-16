using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSetFight : MonoBehaviour
{
	string shipName, bulletName, childName;

	public void SetEquip()
    {
         shipName = PlayerPrefs.GetString("tmpShip1");
		 bulletName = PlayerPrefs.GetString("tmpBullet");
		 childName = PlayerPrefs.GetString("tmpChild");

		if (shipName.Equals("default")) { }else PlayerPrefs.SetString("ShipFight", shipName);

		if (bulletName.Equals("default")) { } else PlayerPrefs.SetString("BulletFight", bulletName);

		if (childName.Equals("default")) { } else PlayerPrefs.SetString("ChildFight", childName);

	}
	
}
