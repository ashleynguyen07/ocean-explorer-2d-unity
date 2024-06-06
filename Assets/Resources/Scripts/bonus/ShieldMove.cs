using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMove : MonoBehaviour
{

    GameObject Player;
	float timeLife;
	float realTime;


	private void Start()
	{
		Player = GameObject.Find("Ship");
		timeLife = 5f;
		realTime = 0;
	}
	void Update()
    {
		realTime += Time.deltaTime;
		gameObject.transform.position = Player.transform.position;
		if (realTime > timeLife)
		{
			Destroy(gameObject);
			PlayerPrefs.SetString("shieldP", "false");
		}
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "bulletE")
		{
			Destroy(collision.gameObject);
			
		}
	}
}
