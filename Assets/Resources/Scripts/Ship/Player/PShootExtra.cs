using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PShootExtra : MonoBehaviour
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
		prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/Extra.prefab", typeof(GameObject));
		Vector3 temp = transform.position;
		temp.x += 0;
		temp.y += 2.3f;
		GameObject tmpObj = Instantiate(prefabObject, temp, Quaternion.identity);
		tmpObj.transform.SetParent(transform, false);
		tmpObj.transform.localPosition = new Vector3(0f, 0f, 0f);
	}
}
