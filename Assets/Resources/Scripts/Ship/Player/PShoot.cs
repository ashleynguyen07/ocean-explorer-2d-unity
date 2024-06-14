using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PShoot : MonoBehaviour
{

	#region Fields

	private GameObject bullet;
	float speedTmp, timeSpeed;
	int i;
	bool check;
	#endregion

	void Start()
	{
		GameObject prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/Bullet_Red.prefab", typeof(GameObject));
		bullet = prefabObject;
		timeSpeed= speedTmp = PlayerPrefs.GetFloat("Speed");
		i = 0;
		check = false;
		StartCoroutine(Shoot());
	}
	private void Update()
	{
        if (speedTmp != PlayerPrefs.GetFloat("Speed"))
        {
			speedTmp = PlayerPrefs.GetFloat("Speed");
			check = true;
		}
       
		if (i < 7&& check)
		{
			timeSpeed += speedTmp*2;
			i++;
			check = false;
		}
	}
	IEnumerator Shoot()
	{
		yield return new WaitForSeconds((0.5f / timeSpeed));
		Vector3 temp = transform.position;
		temp.x += 0;
		temp.y += 2.3f;
		Instantiate(bullet, temp, Quaternion.identity);
		StartCoroutine(Shoot());

	}
}
