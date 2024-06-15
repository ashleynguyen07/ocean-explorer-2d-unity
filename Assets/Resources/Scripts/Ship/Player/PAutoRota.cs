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
		string shipName = PlayerPrefs.GetString("ShipFight");
		if(string.IsNullOrEmpty(shipName))
		{
			shipName = "ship1";
			PlayerPrefs.SetString("ShipFight", "ship1");
		}
		Sprite prefabObject = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/Player/" + shipName + ".png", typeof(Sprite));
		mySprite = prefabObject;

		SpriteRenderer spriteRenderer = myGameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = mySprite;
		AutoRotate customComponent = myGameObject.AddComponent<AutoRotate>();
		

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
