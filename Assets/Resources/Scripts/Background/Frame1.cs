using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Frame1 : MonoBehaviour
{
	[SerializeField]
	GameObject parentObject;
	Sprite mySprite;
	string extend,shipFight, tmpShip;
	bool checkTime;
	int check;
	void Start()
	{
		check = PlayerPrefs.GetInt("check");
		checkTime = true;
		shipFight = PlayerPrefs.GetString("ShipFight");
		tmpShip = PlayerPrefs.GetString("tmpShip");
		string shipName = PlayerPrefs.GetString("ShipFight");
		if (string.IsNullOrEmpty(shipName))
		{
			shipName = "ship1";
			PlayerPrefs.SetString("ShipFight", "ship1");
		}
		UpdateShip(shipName);
		
	}
	private void Update()
	{
		check = PlayerPrefs.GetInt("check");
		shipFight = PlayerPrefs.GetString("ShipFight");
		tmpShip = PlayerPrefs.GetString("tmpShip");
		if (shipFight.Equals(tmpShip) && check == 1)
		{
		}
		else if (check == 1) UpdateShip(tmpShip);
	}
	void UpdateShip(string nameShip)
	{
		if (nameShip.Equals("ship3"))
		{
			extend = ".asset";
		}
		else
		{
			extend = ".png";
		}
		Sprite playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/Player/" + nameShip + extend, typeof(Sprite));
		mySprite = playPrefap;

		if (shipFight.Equals(tmpShip))
		{
			if (checkTime)
			{
				checkTime = false;
			}
			else
			{
				Destroy();
			}
			CreateChildObj();
		}
		else
		{
			Destroy();
			CreateChildObj();
		}
	}

	void CreateChildObj()
	{
		GameObject childGameObject = new GameObject("Playerimage");
		childGameObject.transform.parent = parentObject.transform;

		childGameObject.transform.localPosition = new Vector3(0.01f, 0f, 0f);
		childGameObject.transform.localRotation = Quaternion.identity;
		childGameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);

		SpriteRenderer childSpriteRenderer = childGameObject.AddComponent<SpriteRenderer>();
		childSpriteRenderer.sprite = mySprite;
		childSpriteRenderer.sortingOrder = 1;
	}
	private void Destroy()
	{
		Transform oldChildTranform = parentObject.transform.GetChild(0);
		GameObject oldChildObj = oldChildTranform.gameObject;
		DestroyImmediate(oldChildObj);
		PlayerPrefs.SetInt("check", 0);
	}
}
