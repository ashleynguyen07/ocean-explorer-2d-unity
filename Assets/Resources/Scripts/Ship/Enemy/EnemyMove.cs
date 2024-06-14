using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.AxisState;

public class EnemyMove : MonoBehaviour
{
	float maxY,y;
	public float SpeedMove;


	void Start()
    {
		Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		maxY = bounds.y - 8f;
		y = bounds.y;
	}


	void Update()
	{
		Enemy_Move();
	}
	//======================
	void Enemy_Move()
	{
		if (transform.position.y <= maxY)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
		}
		else
		{
			y -= SpeedMove * Time.deltaTime;
			transform.position = new Vector3(transform.position.x, y, 0f);
		}
	}
}
