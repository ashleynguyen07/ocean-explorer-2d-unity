using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEditor;
using UnityEngine;

public class PAutoRota : MonoBehaviour
{
	Sprite mySprite;
	[SerializeField]
	GameObject myGameObject;

	void Start()
    {
		string shipName = PlayerPrefs.GetString("ShipFight","ship1");
		string childName = PlayerPrefs.GetString("ChildFight");
		string bulletName = PlayerPrefs.GetString("BulletFight");
		string extend="";
		if (shipName.Equals("ship3"))
		{
			extend = ".asset";
		}
		else extend = ".png";
		Sprite prefabObject = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/Player/" + shipName + extend, typeof(Sprite));
		mySprite = prefabObject;

		SpriteRenderer spriteRenderer = myGameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = mySprite;
		AutoRotate customComponent = myGameObject.AddComponent<AutoRotate>();

		if (string.IsNullOrEmpty(childName))
		{
			PlayerPrefs.SetString("ChildFight","default");
		}
		else PlayerPrefs.SetString("ChildFight", childName);


		if (string.IsNullOrEmpty(bulletName))
		{
			PlayerPrefs.SetString("BulletFight", "bulletP1");
		}
		else PlayerPrefs.SetString("BulletFight", bulletName);

		
	}

	
}
public class AutoRotate : MonoBehaviour
{
	private float rotationSpeed = 45f; 
	public void SetRotationSpeed(float speed)
	{
		rotationSpeed = speed;
	}
	private void Update()
	{
		transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
	}
}
