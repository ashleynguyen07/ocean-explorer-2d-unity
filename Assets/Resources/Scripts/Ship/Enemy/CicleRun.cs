using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicleRun : MonoBehaviour
{
	public float radius ;
	public float angularSpeed ;
	private float angle ;
	public float yOffset ;
	private void Start()
	{
		radius = 4f;
		angularSpeed = 1f;
		angle = 0f;
		yOffset = 5f;
		StartCoroutine(circle());
	}

	IEnumerator circle()
	{
		yield return new WaitForSeconds(0.017f);
		float x = Mathf.Cos(angle) * radius;
		float z = Mathf.Sin(angle) * radius + yOffset; ;

		transform.position = new Vector3(x, z, 0f);
		angle += angularSpeed * Time.fixedDeltaTime;
		StartCoroutine(circle());
	}
}
