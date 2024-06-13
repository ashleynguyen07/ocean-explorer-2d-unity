using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollow : MonoBehaviour
{
	public Transform objectToFollow;
	private RectTransform imageRectTransform;
	private Camera mainCamera;

	private void Start()
	{
		imageRectTransform = GetComponent<RectTransform>();
		mainCamera = Camera.main;
	}

	private void Update()
	{
		UpdateImagePosition();
	}

	private void UpdateImagePosition()
	{
		float x = objectToFollow.position.x -6.5f;
		float y = objectToFollow.position.y - 14f;
		Vector3 screenPosition = mainCamera.WorldToScreenPoint(new Vector3(x,y,0f));
		
			imageRectTransform.localPosition = screenPosition;
		
	}

}
