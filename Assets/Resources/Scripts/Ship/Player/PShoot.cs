using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PShoot : MonoBehaviour
{

	#region Fields

	private GameObject bullet;
	float speedTmp;
	#endregion
	
	void Start()
	{
		GameObject prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/Bullet_Red.prefab", typeof(GameObject));
		bullet = prefabObject;
		speedTmp = PlayerPrefs.GetFloat("Speed", 1);
		StartCoroutine(Shoot());
	}
	private void Update()
	{
		speedTmp = PlayerPrefs.GetFloat("Speed", 1);

	}
	IEnumerator Shoot()
	{
		yield return new WaitForSeconds((0.5f/speedTmp));
		Vector3 temp = transform.position;
		temp.x += 0;
		temp.y += 2.3f;
		Instantiate(bullet, temp, Quaternion.identity);
		StartCoroutine(Shoot());

	}
}
