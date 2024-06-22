using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThreeBullet : MonoBehaviour
{
	#region Fields
	GameObject prefabObject;
	string bulletFight;
	#endregion
	void Start()
	{
		UpdateBullet();
	}
	private void UpdateBullet()
	{
		bulletFight = PlayerPrefs.GetString("BulletFight");
		prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/" + bulletFight+".prefab", typeof(GameObject));
		StartCoroutine(ShootBulletLeft());
		StartCoroutine(ShootBulletRight());
	}
	IEnumerator ShootBulletLeft()
	{
		yield return new WaitForSeconds(1f);
		Vector3 temp = transform.position;
		temp.x -= 0.5f;
		temp.y += 1.5f;
		GameObject tmp = Instantiate(prefabObject, temp, Quaternion.identity);
		Rigidbody2D rb = tmp.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-0.2f, +2f);
		StartCoroutine(ShootBulletLeft());
	}
	IEnumerator ShootBulletRight()
	{
		yield return new WaitForSeconds(1f);
		Vector3 temp = transform.position;
		temp.x += 0.5f;
		temp.y += 1.5f;
		GameObject tmp= Instantiate(prefabObject, temp, Quaternion.identity);
		Rigidbody2D rb = tmp.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(+0.2f, 2f);
		StartCoroutine(ShootBulletRight());
	}
}
