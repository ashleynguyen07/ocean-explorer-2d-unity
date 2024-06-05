using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PMove : MonoBehaviour
{
	#region Fields
	public float SpeedMove;
	private Rigidbody2D rb;
	#endregion
	//=========================
	void Start()
	{
		GameObject prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Player/ship1.prefab", typeof(GameObject));
		GameObject childObject = Instantiate(prefabObject, transform);
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
