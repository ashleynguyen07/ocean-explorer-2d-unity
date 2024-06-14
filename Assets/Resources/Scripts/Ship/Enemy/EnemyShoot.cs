using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
	[SerializeField]
	GameObject bullet;
	void Start()
    {
		InvokeRepeating("Shoot", 1f, 1f);
	}

	void Shoot()
	{
		Vector3 temp = transform.position;
		temp.y -= 1.5f;
		Instantiate(bullet, temp, Quaternion.identity);
	}
}
