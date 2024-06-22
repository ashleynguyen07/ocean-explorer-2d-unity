using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CateP : MonoBehaviour
{
	[SerializeField]
	GameObject parentObject;
	GameObject childGameObject;
	GameObject playPrefap;

	GameObject childOfChildObj;
	GameObject childPrefap;

	string shipFight, tmpShip, childFight, tmpChild;
	int check;
	bool checkTime;
	void Start()
	{
		checkTime = true;
		PlayerPrefs.SetString("tmpShip1", "default");
		PlayerPrefs.SetString("tmpChild", "default");
		PlayerPrefs.SetString("tmpBullet", "default");
		UpdateShip();
	}
	void Update()
	{
		check = PlayerPrefs.GetInt("check");
		if (check == 1) UpdateShip();
	}
	 void UpdateShip()
	{
		shipFight = PlayerPrefs.GetString("ShipFight", "ship1");
		tmpShip = PlayerPrefs.GetString("tmpShip1");
		tmpChild = PlayerPrefs.GetString("tmpChild");
		childFight = PlayerPrefs.GetString("ChildFight");
		if (tmpShip.Equals("default"))
		{
			playPrefap = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Player/" + shipFight + ".prefab", typeof(GameObject));
		}
		else
		{
			playPrefap = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Player/" + tmpShip + ".prefab", typeof(GameObject));
		}
		if (shipFight.Equals(tmpShip))
		{
			if (checkTime)
			{
				CreateChild();
				checkTime = false;
			}
			else
			{
				 Destroy();
				CreateChild();
			}
		}
		else
		{
			checkTime = false;
			Destroy();
			CreateChild();
		}

		if (tmpChild == "default" && childFight == "default")
		{

		}
		else if (tmpChild == "default")
		{
			childPrefap = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Childs/" + childFight + ".prefab", typeof(GameObject));
			StartCoroutine(FindChild("fight"));
		}
		else
		{
			childPrefap = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Childs/" + tmpChild + ".prefab", typeof(GameObject));
			StartCoroutine(FindChild("notFight"));
		}
	}
	IEnumerator FindChild(string checkChildFight)
	{
		yield return new WaitForSeconds(0.001f);
		if (parentObject != null && parentObject.transform.childCount > 0)
		{
			Transform oldChildTransform = parentObject.transform.GetChild(0);
			if (oldChildTransform != null)
			{
				GameObject oldChildObj = oldChildTransform.gameObject;
				if (oldChildObj != null && oldChildObj.transform.childCount > 0)
				{
					Transform transformChildOfChild = oldChildObj.transform.GetChild(0);
					if (transformChildOfChild != null)
					{
						GameObject oldChildOfChild = transformChildOfChild.gameObject;
						GameObject.Destroy(oldChildOfChild);
					}
				}
				childOfChildObj = Instantiate(childPrefap, oldChildObj.transform);
				childOfChildObj.transform.SetParent(oldChildObj.transform);
				if (checkChildFight.Equals("notFight"))
				{
						childOfChildObj.transform.localPosition = new Vector3(2.47f, 2f, 0f);
				}else
				{
						childOfChildObj.transform.localPosition = new Vector3(2.47f, 2f, 0f);
				}
				StartCoroutine(OffCheck());
			}
		}
	}
	void Destroy()
	{
		if (parentObject != null && parentObject.transform.childCount > 0)
		{
			Transform oldChildTransform = parentObject.transform.GetChild(0);
			if (oldChildTransform != null)
			{
				GameObject oldChildObj = oldChildTransform.gameObject;
				GameObject.Destroy(oldChildObj);
			}
		}
	}
	void CreateChild()
	{
		childGameObject = Instantiate(playPrefap, transform);
		childGameObject.transform.SetParent(parentObject.transform);
	}
	IEnumerator OffCheck()
	{
		yield return new WaitForSeconds(0.0001f);
	}
}
