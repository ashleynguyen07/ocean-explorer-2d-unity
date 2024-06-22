using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBackground : MonoBehaviour
{
	#region Fields
	private Vector2 offset = Vector2.zero;
	private Material material;

	float  timeSpeed;
	bool checkCallOneTimeExtra;
	int checkExtra;
	#endregion
	void Start()
	{
		PlayerPrefs.SetInt("SpeedExtra", 0);
		var woldHeight = Camera.main.orthographicSize * 2f;
		var woldWidth = woldHeight * Screen.width / Screen.height;
		transform.localScale = new Vector3(woldWidth, woldHeight, 0f);

		material = GetComponent<Renderer>().material;
		offset = material.GetTextureOffset("_MainTex");
		checkCallOneTimeExtra = true;
	}
	void Update()
	{
		checkExtra = PlayerPrefs.GetInt("SpeedExtra", 0);
		if (checkExtra == 1)
		{
			if (checkCallOneTimeExtra)
			{
				StartCoroutine(SpeedExtra());
				checkCallOneTimeExtra = false;
			}
		}
		else 
		{
			timeSpeed = PlayerPrefs.GetFloat("Speed");
		}
		offset.y += timeSpeed * 0.3f * Time.deltaTime;
		material.SetTextureOffset("_MainTex", offset);
	}
	IEnumerator SpeedExtra()
	{
		float tmp = timeSpeed;
		timeSpeed = 5f;
		yield return new WaitForSeconds(10);
		timeSpeed = tmp;
		PlayerPrefs.SetInt("SpeedExtra", 0);
		checkCallOneTimeExtra = true;	
	}
}
