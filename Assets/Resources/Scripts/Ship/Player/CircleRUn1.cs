using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRUn1 : MonoBehaviour
{
	 float radius,angularSpeed,angle;
	Rigidbody2D rb;
	bool checkCallFun;
	private void Start()
	{
		transform.rotation = Quaternion.Euler(0, 0, 180);
		radius = 4f;
		angularSpeed = 1f;
		angle = 90f;
		checkCallFun = true;
		rb = GetComponent<Rigidbody2D>();
		Move();
	}
	private void Update()
	{
		int checkExtra = PlayerPrefs.GetInt("SpeedExtra", 0);
		if (checkExtra == 1 && transform.position.y > 5.07f)
		{
			CancelInvoke("circle");
			checkCallFun = true;
		}
		else if (transform.position.y <= 5.07f && checkCallFun)
		{
			checkCallFun = false;
			rb.velocity = Vector2.zero;
			InvokeRepeating("circle", 0f, 0.0175f);
		}
		else Move();
	}
	void circle()
	{
		float x = Mathf.Cos(angle) * radius;
		float z = (Mathf.Sin(angle) * radius);
		transform.position = new Vector3(x, 0f, z);
		angle += angularSpeed * Time.fixedDeltaTime;
	}
	void Move()
	{
		rb.velocity = new Vector2(0f, -3f);
	}
}
