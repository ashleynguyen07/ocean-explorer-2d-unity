using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToPoint : MonoBehaviour
{
	float speed = 3f;

	Vector3[] curvePoints = new Vector3[]
{
	new Vector3(0, 0, 0),     // ?i?m ??u
    new Vector3(2, 3, 0),     // ?i?m ?i?u khi?n 1
    new Vector3(4, -2, 0),    // ?i?m ?i?u khi?n 2
    new Vector3(6, 0, 0)      // ?i?m cu?i
};

	int currentIndex;
	void Start()
	{
		Vector3 currentPos = transform.position;
		Vector3 targetPos = curvePoints[currentIndex];
		transform.position = Vector3.Lerp(currentPos, targetPos, Time.deltaTime * speed);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
