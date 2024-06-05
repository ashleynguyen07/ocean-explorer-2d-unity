using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PShoot4: MonoBehaviour
{

	#region Fields

	private GameObject bullet;

	#endregion
	
	void Start()
	{
		GameObject prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/Bullet_Red.prefab", typeof(GameObject));
		bullet = prefabObject;
		InvokeRepeating("Shoot", 0f, 0.2f);
	}

	void Shoot()
	{
		Vector3 temp = transform.position;
		temp.x += 0;
		temp.y += 2.3f;
		Instantiate(bullet, temp, Quaternion.identity);

	}
}
