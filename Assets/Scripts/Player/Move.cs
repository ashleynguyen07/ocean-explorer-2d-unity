using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	#region Fields
	public float SpeedMove;
	private Rigidbody2D rb;
	[SerializeField]
	private GameObject bullet;

	#endregion
	//=========================
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		InvokeRepeating("Shoot", 0f, 0.2f);
	}

	// Update is called once per frame
	void Update()
	{
		PlaneMove();

	}
	//====================
	void PlaneMove()
	{
		float xAxix = Input.GetAxisRaw("Horizontal") * SpeedMove;
		float yAxis = Input.GetAxisRaw("Vertical") * SpeedMove;
		rb.velocity = new Vector2(xAxix, yAxis);
	}

	//=====================

	void Shoot()
	{
		
		Vector3 temp = transform.position;
		temp.x -= 1f;
		temp.y += 2.3f;
		Instantiate(bullet, temp, Quaternion.identity);
		
	}
	

}
