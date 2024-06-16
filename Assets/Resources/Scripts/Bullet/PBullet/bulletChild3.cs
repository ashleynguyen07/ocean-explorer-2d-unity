using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bulletChild3 : MonoBehaviour
{
	[SerializeField]
	 GameObject bullet;
	float speedTmp, timeSpeed;
	int i;
	bool check;
	void Start()
    {
		timeSpeed = speedTmp = PlayerPrefs.GetFloat("Speed");
		i = 0;
		check = false;
		StartCoroutine(ShootLeft());

		StartCoroutine(ShootRight());
	}

    // Update is called once per frame
    void Update()
    {
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
	}
	IEnumerator ShootLeft()
	{
		yield return new WaitForSeconds((1.5f / timeSpeed));
		Vector3 temp = transform.position;
		temp.x -= 4.4f;
		temp.y -= 1.5f;
		Instantiate(bullet, temp, Quaternion.Euler(0f, 0f, 90f));
		StartCoroutine(ShootLeft());

	}
	IEnumerator ShootRight()
	{
		yield return new WaitForSeconds((1.5f / timeSpeed));
		Vector3 temp = transform.position;
		temp.x -= 0.5f;
		temp.y -= 1.5f;
		Instantiate(bullet, temp, Quaternion.Euler(0f, 0f, 90f));
		StartCoroutine(ShootRight());

	}
}
