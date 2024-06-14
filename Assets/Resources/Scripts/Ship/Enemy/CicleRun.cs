using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CicleRun : MonoBehaviour
{
	public float radius ;
	public float angularSpeed ;
	private float angle ;
	public float yOffset ;
	Rigidbody2D rb;
	bool check;
	private void Start()
	{
		transform.rotation = Quaternion.Euler(0, 0, 180);
		radius = 4f;
		angularSpeed = 1f;
		angle = 0f;
		yOffset = 5f;
		check = true;
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(0f, -3f);
		
	}
	private void Update()
	{
		
		if (transform.position.y <= 5.07f && check)
		{
			check = false;
			rb.velocity = Vector2.zero;
			StartCoroutine(circle());
		}
	}
	IEnumerator circle()
	{
		yield return new WaitForSeconds(0.017f);
		float x = Mathf.Cos(angle) * radius;
		float z = (Mathf.Sin(angle) * radius - yOffset); 
		
		transform.position = new Vector3(x, -z, 0f);
		angle += angularSpeed * Time.fixedDeltaTime;
		StartCoroutine(circle());
	}
}
