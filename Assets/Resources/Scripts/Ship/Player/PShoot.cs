using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PShoot : MonoBehaviour
{
	#region Fields
	GameObject prefabObject;
	float  timeSpeed;
	int  check1;
	bool callRoketOneTime, callThreeBulletOneTime;
	string tmpbullet, bulletFight;
	#endregion
	void Start()
	{
		callThreeBulletOneTime=callRoketOneTime = true;
		timeSpeed = PlayerPrefs.GetFloat("Speed") ;
		UpdateBullet();
	}
	private void Update()
	{
		check1 = PlayerPrefs.GetInt("check");
		timeSpeed = PlayerPrefs.GetFloat("Speed");
		if (check1 == 1) UpdateBullet();

		if (PlayerPrefs.GetInt("Roket", 0) == 1 && callRoketOneTime)
		{
			gameObject.AddComponent<BulletRoket>();
			callRoketOneTime=false;
			StartCoroutine(OffRocket());
		}

		if(PlayerPrefs.GetInt("ThreeRoket",0) ==1 && callThreeBulletOneTime)
		{
			gameObject.AddComponent<ThreeBullet>();
			callThreeBulletOneTime = false;
			PlayerPrefs.SetInt("ThreeRoket", 0);
		}
	}
	IEnumerator OffRocket()
	{
		yield return new WaitForSeconds(10f);
		PlayerPrefs.SetInt("Roket", 0);
		callRoketOneTime = true;
		Destroy(GetComponent<BulletRoket>());
	}
	private void UpdateBullet()
	{
		tmpbullet = PlayerPrefs.GetString("tmpBullet");
		bulletFight = PlayerPrefs.GetString("BulletFight");
		if (tmpbullet.Equals("default"))
		{
			prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/playerbullet/" + bulletFight + ".prefab", typeof(GameObject));
		}
		else
		{
			prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/playerbullet/" + tmpbullet + ".prefab", typeof(GameObject));
		}
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
			if (tmpbullet.Equals("bulletP3")) Instantiate(prefabObject, temp, Quaternion.Euler(0, 0, 90f));
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
