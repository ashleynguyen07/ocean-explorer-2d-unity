using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float SpeedMove;
	[SerializeField]
	private GameObject bullet;
	public Vector3 move;
	float maxY;
	float y;
	void Start()
	{
		Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		maxY = bounds.y-8f;
		InvokeRepeating("Shoot", 1f, 1f);
		y = bounds.y;
	}
	void Update()
	{
		EnemyMove();
	}
	void EnemyMove()
	{
		if (transform.position.y <= maxY)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
		}
		else {
			y -= SpeedMove * Time.deltaTime;
			transform.position = new Vector3(transform.position.x, y, 0f);
		}
	}
	void Shoot()
	{
		Vector3 temp = transform.position;
		temp.y -= 1.5f;
		Instantiate(bullet, temp, Quaternion.identity);
	}
}
