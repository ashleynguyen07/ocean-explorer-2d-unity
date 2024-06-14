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
	bool check;
	[SerializeField]
	GameObject parentObj;

	#endregion
	//=========================
	void Start()
	{
		check = true;
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
		if (check)
		{
			GameObject childObject = Instantiate(prefabObject, transform);
			childObject.transform.SetParent(parentObj.transform);
			check = false;
		}
		else
		{
			Transform oldChildTranform = parentObj.transform.GetChild(0);
			GameObject oldChildObj = oldChildTranform.gameObject;
			DestroyImmediate(oldChildObj);

			GameObject childObject = Instantiate(prefabObject, transform);
			childObject.transform.SetParent(parentObj.transform);
			StartCoroutine(ReturnShip());
		}
		rb = GetComponent<Rigidbody2D>();
		
	}
	IEnumerator ReturnShip()
	{
		yield return new WaitForSeconds(3);
		Ship(PlayerPrefs.GetString("Childinitial"));
	}

}
