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
	GameObject childGameObject;
	GameObject playPrefap;
	string shipFight, tmpShip;
	int check;
	bool checkTime;
	void Start()
	{
		checkTime = true;
		PlayerPrefs.SetString("tmpShip", "default");
		UpdateShip();
	}
	 void Update()
	{
		check = PlayerPrefs.GetInt("check");
		if (check == 1) UpdateShip();
	}
	void UpdateShip()
	{
		shipFight = PlayerPrefs.GetString("ShipFight", "ship1");
		tmpShip = PlayerPrefs.GetString("tmpShip");

		if (tmpShip.Equals("default"))
		{
			playPrefap = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Player/" + shipFight + ".prefab", typeof(GameObject));
		}
		else
		{
			playPrefap = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Player/" + tmpShip + ".prefab", typeof(GameObject));
		}

		if (shipFight.Equals(tmpShip))
		{
			if (checkTime)
			{
				CreateChild();
				checkTime = false;
			}
			else
			{
				Destroy();
				CreateChild();
			}
		}
		else
		{
			Destroy();
			CreateChild();
		}
	}
	private void Destroy()
	{
		if (parentObject != null && parentObject.transform.childCount > 0)
		{
			Transform oldChildTransform = parentObject.transform.GetChild(0);
			if (oldChildTransform != null)
			{
				GameObject oldChildObj = oldChildTransform.gameObject;
				GameObject.Destroy(oldChildObj);
			}
		}
	}
	void CreateChild()
	{
		childGameObject = Instantiate(playPrefap, transform);
		childGameObject.transform.SetParent(parentObject.transform);
	}
}
