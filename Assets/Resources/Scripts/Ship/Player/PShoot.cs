using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PShoot : MonoBehaviour
{
	#region Fields
	GameObject prefabObject;
	float speedTmp, timeSpeed;
	int i, check1;
	bool check;
	string tmpbullet, bulletFight;
	#endregion

	void Start()
	{
		i = 0;
		check = false;
		UpdateBullet();
	}
	private void Update()
	{
		check1 = PlayerPrefs.GetInt("check");
		if (speedTmp != PlayerPrefs.GetFloat("Speed"))
		{
			speedTmp = PlayerPrefs.GetFloat("Speed");
			check = true;
		}
		if (i < 7 && check)
		{
			timeSpeed += speedTmp * 2;
			i++;
			check = false;
		}
		if (check1 == 1) UpdateBullet();
	}
	private void UpdateBullet()
	{
		tmpbullet = PlayerPrefs.GetString("tmpBullet");
		bulletFight = PlayerPrefs.GetString("BulletFight");
		if ( tmpbullet.Equals("default"))
		{
			prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/playerbullet/" + bulletFight + ".prefab", typeof(GameObject));
		}
		else
		{
			prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/playerbullet/" + tmpbullet + ".prefab", typeof(GameObject));
		}
		timeSpeed = speedTmp = PlayerPrefs.GetFloat("Speed");
		StartCoroutine(Shoot());
		StartCoroutine(Offcheck());
	}

	IEnumerator Shoot()
	{
		yield return new WaitForSeconds((0.5f / timeSpeed));
		Vector3 temp = transform.position;
		temp.x += 0;
		temp.y += 2.3f;
		if (tmpbullet.Equals("default"))
		{
			if (bulletFight.Equals("bulletP3")) Instantiate(prefabObject, temp, Quaternion.Euler(0, 0, 90f));
			else Instantiate(prefabObject, temp, Quaternion.identity);
		}
		else
		{
			if(tmpbullet.Equals("bulletP3")) Instantiate(prefabObject, temp, Quaternion.Euler(0, 0, 90f));
			else Instantiate(prefabObject, temp, Quaternion.identity);
		}
		StartCoroutine(Shoot());
	}
	IEnumerator Offcheck()
	{
		yield return new WaitForSeconds(0.00001f);
		PlayerPrefs.SetInt("check", 0);
	}
}
