using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Frame2 : MonoBehaviour
{
	[SerializeField]
	GameObject parentObject;
	Sprite playPrefap;
	GameObject childGameObject;

	string extend, bulletFight, tmpbullet;
	int check;
	void Start()
	{
		PlayerPrefs.SetString("tmpBullet", "default");
		UpdateBullet();
	}
	void Update()
	{
		check = PlayerPrefs.GetInt("check");
		if (check == 1) UpdateBullet();
	}
	void UpdateBullet()
	{
		bulletFight = PlayerPrefs.GetString("BulletFight", "bulletP1");
		tmpbullet = PlayerPrefs.GetString("tmpBullet");

		if (tmpbullet.Equals("bulletP1"))
		{
			extend = ".png";
		}
		else
		{
			extend = ".asset";
		}
		if (tmpbullet.Equals("default"))
		{
			if (bulletFight.Equals("bulletP1"))
			{
				playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/bullet/" + bulletFight + ".png", typeof(Sprite));
			}
			else
			{
				playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/bullet/" + bulletFight + extend, typeof(Sprite));
			}
		}
		else
		{
			playPrefap = (Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/Sprites/bullet/" + tmpbullet + extend, typeof(Sprite));
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
			if (bulletFight.Equals("bulletP3") || tmpbullet.Equals("bulletP3"))
			{
				childGameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
			}
			else childGameObject.transform.localRotation = Quaternion.identity;


			childGameObject.transform.localScale = new Vector3(0.35f, 0.35f, 0f);
		}
		else
		{
			SpriteRenderer spriteRenderer = childGameObject.GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = playPrefap;
			spriteRenderer.sortingOrder = 1;

			childGameObject.transform.localPosition = new Vector3(0.01f, 0f, 0f);
			if (bulletFight.Equals("bulletP3") || tmpbullet.Equals("bulletP3"))
			{
				childGameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
			}
			else childGameObject.transform.localRotation = Quaternion.identity;
			childGameObject.transform.localScale = new Vector3(0.35f, 0.35f, 0f);
		}
		

	}
}
