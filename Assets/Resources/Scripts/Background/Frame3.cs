using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Frame3 : MonoBehaviour
{
	[SerializeField]
	GameObject parentObject;
	Sprite playPrefap;
	GameObject childGameObject;

	string extend, childFight, tmpChild;
	int check;
	void Start()
	{
		PlayerPrefs.SetString("tmpChild", "default");

		UpdateChild();
	}
	void Update()
	{
		check = PlayerPrefs.GetInt("check");
		if (check == 1) UpdateChild();
	}
	void UpdateChild()
	{
		childFight = PlayerPrefs.GetString("ChildFight");
		tmpChild = PlayerPrefs.GetString("tmpChild");

		if (tmpChild.Equals("child2"))
		{
			extend = "left.png";
		}
		else
		{
			extend = "left.asset";
		}
		if (tmpChild.Equals("default"))
		{
			if (childFight.Equals("child2"))
			{
				playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/child/" + childFight + "left.png", typeof(Sprite));
			}
			else
			{
				playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/child/" + childFight + extend, typeof(Sprite));
			}
		}
		else
		{
			playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/Ships/child/" + tmpChild + extend, typeof(Sprite));
		}
		CreateChildObj();
	}
	void CreateChildObj()
	{
		if (parentObject != null && parentObject.transform.childCount <= 0)
		{
			childGameObject = new GameObject("Playerimage");
			childGameObject.transform.parent = parentObject.transform;
			SpriteRenderer childSpriteRenderer = childGameObject.AddComponent<SpriteRenderer>();

			childSpriteRenderer.sprite = playPrefap;
			childSpriteRenderer.sortingOrder = 1;
			childGameObject.transform.localPosition = new Vector3(0.01f, 0f, 0f);

			childGameObject.transform.localRotation = Quaternion.identity;
			if (tmpChild.Equals("child3"))
			{
				childGameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0f);
			}else childGameObject.transform.localScale = new Vector3(0.18f, 0.18f, 0f);

		}
		else
		{
			SpriteRenderer spriteRenderer = childGameObject.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = playPrefap;
			spriteRenderer.sortingOrder = 1;

			childGameObject.transform.localPosition = new Vector3(0.01f, 0f, 0f);
			childGameObject.transform.localRotation = Quaternion.identity;
			if (tmpChild.Equals("child3"))
			{
				childGameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0f);
			}
			else childGameObject.transform.localScale = new Vector3(0.18f, 0.18f, 0f);
		}


	}
}
