using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CateP : MonoBehaviour
{

	[SerializeField]
	GameObject parentObject;

	string shipFight, tmpShip;
	int check;
	bool checkTime;
	void Start()
	{
		checkTime = true;
		check = PlayerPrefs.GetInt("check");
		shipFight = PlayerPrefs.GetString("ShipFight");
		tmpShip = PlayerPrefs.GetString("tmpShip");
		string shipName = PlayerPrefs.GetString("ShipFight");
		if (string.IsNullOrEmpty(shipName))
		{
			shipName = "ship1";
			PlayerPrefs.SetString("ShipFight", "ship1");
		}
		PlayerPrefs.SetString("tmpShip", shipName);
		//========================================
		UpdateShip(shipName);

	}

	private void Update()
	{
		check = PlayerPrefs.GetInt("check");
		shipFight = PlayerPrefs.GetString("ShipFight");
		tmpShip = PlayerPrefs.GetString("tmpShip");
		if (shipFight.Equals(tmpShip)&& check == 1)
		{
			UpdateShip(tmpShip);
		}
		else if (check == 1) UpdateShip(tmpShip);
	}

	void UpdateShip(string nameShip)
	{
		GameObject playPrefap = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Player/" + nameShip + ".prefab", typeof(GameObject));
		GameObject childGameObject = Instantiate(playPrefap, transform);

		if (shipFight.Equals(tmpShip))
		{
			if (checkTime)
			{
				childGameObject.transform.SetParent(parentObject.transform);
				checkTime= false;
			}
			else
			{
				Destroy();
				childGameObject.transform.SetParent(parentObject.transform);
				PlayerPrefs.SetInt("check", 0);
			}
		}
		else
		{
			Destroy();
			childGameObject.transform.SetParent(parentObject.transform);
			PlayerPrefs.SetInt("check", 0);
		}
	}
	private void Destroy()
	{
		Transform oldChildTranform = parentObject.transform.GetChild(0);
		GameObject oldChildObj = oldChildTranform.gameObject;
		DestroyImmediate(oldChildObj);
	}


}
