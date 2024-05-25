using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float SpeedMove;
	private Rigidbody2D rb;
	[SerializeField]
	private GameObject bullet;
	//========================
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		InvokeRepeating("Shoot", 1f, 1f);
	}
	// Update is called once per frame
	void Update()
	{
		EnemyMove();
	}
	//======================
	void EnemyMove()
	{
		rb.velocity = new Vector2(0f, -SpeedMove);
	}

	//=====================

	void Shoot()
	{

		Vector3 temp = transform.position;
		temp.y -= 1.5f;
		Instantiate(bullet, temp, Quaternion.identity);

	}
	//===================
	
}
