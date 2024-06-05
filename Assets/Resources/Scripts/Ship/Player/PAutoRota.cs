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


	Sprite someOtherSprite;

	void Start()
    {
		string shipName = PlayerPrefs.GetString("ShipFight");
		if(string.IsNullOrEmpty(shipName))
		{
			shipName = "ship1";
		}

		Sprite prefabObject = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/Player/" + shipName + ".png", typeof(Sprite));
		mySprite = prefabObject;
		

		//========================================
		GameObject emptyGameObject = myGameObject;
		SpriteRenderer spriteRenderer = emptyGameObject.AddComponent<SpriteRenderer>();
		
		spriteRenderer.sprite = mySprite;
		AutoRotate customComponent = emptyGameObject.AddComponent<AutoRotate>();

		GameObject childGameObject = new GameObject("PlayerWeapon");

		// ??t GameObject con là con c?a GameObject "Player"
		childGameObject.transform.parent = emptyGameObject.transform;

		// ?i?u ch?nh v? trí, rotation và scale c?a GameObject con
		childGameObject.transform.localPosition = new Vector3(0.5f, 0f, 0f);
		childGameObject.transform.localRotation = Quaternion.identity;
		childGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

		// Thêm các component khác vào GameObject con n?u c?n
		SpriteRenderer childSpriteRenderer = childGameObject.AddComponent<SpriteRenderer>();
		childSpriteRenderer.sprite = someOtherSprite;

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
