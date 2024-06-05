using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class PAutoRota : MonoBehaviour
{
	[SerializeField]
	Sprite mySprite;

	[SerializeField]
	Sprite someOtherSprite;

	void Start()
    {
		GameObject emptyGameObject = new GameObject("Player");
		SpriteRenderer spriteRenderer = emptyGameObject.AddComponent<SpriteRenderer>();
		
		spriteRenderer.sprite = mySprite;
		AutoRotate customComponent = emptyGameObject.AddComponent<AutoRotate>();

		GameObject childGameObject = new GameObject("PlayerWeapon");

		// ??t GameObject con l� con c?a GameObject "Player"
		childGameObject.transform.parent = emptyGameObject.transform;

		// ?i?u ch?nh v? tr�, rotation v� scale c?a GameObject con
		childGameObject.transform.localPosition = new Vector3(0.5f, 0f, 0f);
		childGameObject.transform.localRotation = Quaternion.identity;
		childGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

		// Th�m c�c component kh�c v�o GameObject con n?u c?n
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
