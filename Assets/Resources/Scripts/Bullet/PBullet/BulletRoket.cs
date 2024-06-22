using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletRoket : MonoBehaviour
{
	#region Fields
	GameObject prefabObject;
	#endregion

	void Start()
	{
		UpdateBullet();
	}
	private void UpdateBullet()
	{
		prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/Missile_1.prefab", typeof(GameObject));
		StartCoroutine(ShootBulletLeft());
		StartCoroutine(ShootBulletRight());
	}
	IEnumerator ShootBulletLeft()
	{
		yield return new WaitForSeconds(2f);
		Vector3 temp = transform.position;
		temp.x -= 0.8f;
		temp.y += 1.5f;
		Instantiate(prefabObject, temp, Quaternion.identity);
		StartCoroutine(ShootBulletLeft());
	}
	IEnumerator ShootBulletRight()
	{
		yield return new WaitForSeconds(2f);
		Vector3 temp = transform.position;
		temp.x += 0.8f;
		temp.y += 1.5f;
		Instantiate(prefabObject, temp, Quaternion.identity);
		StartCoroutine(ShootBulletRight());
	}

}
