using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PMove : MonoBehaviour
{
	#region Fields
	public float SpeedMove;
	private Rigidbody2D rb;
	bool checkFirst, checkTimeReturn;
	[SerializeField]
	GameObject parentObj;

	#endregion
	//=========================
	void Start()
	{
		checkTimeReturn = checkFirst = true;
		PlayerPrefs.SetString("tmpBullet", "default");
		string shipName = PlayerPrefs.GetString("ShipFight");
		if (string.IsNullOrEmpty(shipName))
		{
			shipName = "ship1";
		}
		PlayerPrefs.SetString("Childinitial", shipName);
		Ship(shipName);
	}
	// Update is called once per frame
	void Update()
	{
		PlaneMove();
	}
	void PlaneMove()
	{
		float xAxix = Input.GetAxisRaw("Horizontal") * SpeedMove;
		float yAxis = Input.GetAxisRaw("Vertical") * SpeedMove;
		rb.velocity = new Vector2(xAxix, yAxis);
	}
	public void Ship(string shipName)
	{
		GameObject prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Player/" + shipName + ".prefab", typeof(GameObject));
		if (checkFirst)
		{
			//Sinh Ship lan dau tien
			GameObject childObject = Instantiate(prefabObject, transform);
			childObject.transform.SetParent(parentObj.transform);
			checkFirst = false;
			if (PlayerPrefs.GetString("ChildFight") != "default")
			{
				GameObject prefabObjectChild = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Childs/" + PlayerPrefs.GetString("ChildFight") + ".prefab", typeof(GameObject));
				GameObject childChildObject = Instantiate(prefabObjectChild, transform);
				childChildObject.transform.SetParent(childObject.transform);
				childChildObject.transform.localPosition = new Vector3(2.4f, 1.7f, 0f);
			}
		}
		else
		{
			//bien hinh === 
			Transform oldChildTranform = parentObj.transform.GetChild(0);
			GameObject oldChildObj = oldChildTranform.gameObject;
			DestroyImmediate(oldChildObj);

			GameObject childObject = Instantiate(prefabObject, transform);
			childObject.transform.SetParent(parentObj.transform);

			if (PlayerPrefs.GetString("ChildFight") != "default")
			{
				GameObject prefabObjectChild = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Childs/" + PlayerPrefs.GetString("ChildFight") + ".prefab", typeof(GameObject));
				GameObject childChildObject = Instantiate(prefabObjectChild, transform);
				childChildObject.transform.SetParent(childObject.transform);
				childChildObject.transform.localPosition = new Vector3(2.4f, 1.7f, 0f);
			}

			if (checkTimeReturn) StartCoroutine(ReturnShip());
		}
		rb = GetComponent<Rigidbody2D>();
		checkTimeReturn = true;
	}
	IEnumerator ReturnShip()
	{
		yield return new WaitForSeconds(10);
		checkTimeReturn = false;
		Ship(PlayerPrefs.GetString("Childinitial"));
	}
}
