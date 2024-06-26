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

	[SerializeField]
	GameObject parentObj;
	#endregion
	//=========================
	void Start()
	{
		string shipName = PlayerPrefs.GetString("ShipFight");
		if (string.IsNullOrEmpty(shipName))
		{
			shipName = "ship1";
		}

		GameObject prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Player/" + shipName + ".prefab", typeof(GameObject));

		
		GameObject childObject = Instantiate(prefabObject, transform);

		/*childObject.transform.position = parentObj.transform.position;
		childObject.transform.rotation = parentObj.transform.rotation;
		childObject.transform.localScale = parentObj.transform.localScale;*/
		childObject.transform.SetParent(parentObj.transform);

		//================================
		rb = GetComponent<Rigidbody2D>();

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

}
