using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Frame1 : MonoBehaviour
{
	[SerializeField]
	GameObject parentObject;
	Sprite playPrefap;
	GameObject childGameObject;
	
	string extend, shipFight, tmpShip;
	int check;
	
	void Start()
	{
		Debug.Log("heloooo");
		PlayerPrefs.SetString("tmpShip1", "default");
		UpdateShip();
	}
	void Update()
	{
		check = PlayerPrefs.GetInt("check");
		if (check == 1) UpdateShip();
	}
	void UpdateShip()
	{
		Debug.Log("heloooo111");

		shipFight = PlayerPrefs.GetString("ShipFight","ship1");
		tmpShip = PlayerPrefs.GetString("tmpShip1");

		if (tmpShip.Equals("ship3"))
		{
			extend = ".asset";
		}
		else
		{
			extend = ".png";
		}
		if (tmpShip.Equals("default"))
		{
			if (shipFight.Equals("ship3"))
			{
				playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/Player/" + shipFight + ".asset", typeof(Sprite));
			}
			else
			{
				playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/Player/" + shipFight +  extend, typeof(Sprite));
			}
		}
		else
		{
			playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/Player/" + tmpShip + extend, typeof(Sprite));
		}
			CreateChildObj();
	}
	void CreateChildObj()
	{
		if (parentObject != null && parentObject.transform.childCount <= 0)
		{
			childGameObject = new GameObject("Playerimage");
			childGameObject.transform.parent = parentObject.transform;
			SpriteRenderer childSpriteRenderer = childGameObject.AddComponent<SpriteRenderer>();

			childSpriteRenderer.sprite = playPrefap;
			childSpriteRenderer.sortingOrder = 1;
			childGameObject.transform.localPosition = new Vector3(0.01f, 0f, 0f);

			childGameObject.transform.localRotation = Quaternion.identity;
			childGameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
		}
		else
		{
			SpriteRenderer spriteRenderer = childGameObject.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = playPrefap;
			spriteRenderer.sortingOrder = 1;

			childGameObject.transform.localPosition = new Vector3(0.01f, 0f, 0f);
			childGameObject.transform.localRotation = Quaternion.identity;
			childGameObject.transform.localScale = new Vector3(0.09f, 0.09f, 0f);
		}
		
	}
}
