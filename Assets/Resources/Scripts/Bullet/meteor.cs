using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
	public GameObject childObject;
	Rigidbody2D rb;
	bool check;
	float minX, maxX, x;
	void Start()
	{
		Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		minX = -bound.x+1f; maxX = bound.x-1.5f;
		

		rb = GetComponent<Rigidbody2D>();
		 x = Random.value < 0.5f ? -3f : 3f;
		rb.velocity = new Vector2(x, 0f);
	}

	// Update is called once per frame
	void Update()
	{
		MoveX();
		
		StartCoroutine(SomeMethod());
		StartCoroutine(MoveY());
	}
	IEnumerator SomeMethod()
	{
		yield return new WaitForSeconds(2);
		childObject.gameObject.SetActive(false);
	}
	IEnumerator MoveY()
	{
		yield return new WaitForSeconds(2.5f);
		rb.velocity = new Vector2(0, -6f);
	}
	void MoveX()
	{
		
		if (transform.position.x < minX) rb.velocity = new Vector2(-x, 0f);
		if (transform.position.x > maxX) rb.velocity = new Vector2(-x, 0f);
	}

}
