using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus_move : MonoBehaviour
{
	#region Fields 
	float x, y;
	private Rigidbody2D rb;
	#endregion
	void Start()
	{
		x = -2f;
		y = -1f;
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(x, y);
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "BottomBoxBound" )
		{
			Destroy(gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "MainCamera")
		{
			x = -x;
			rb.velocity = new Vector2(x, y);
		}
	}
	
}
