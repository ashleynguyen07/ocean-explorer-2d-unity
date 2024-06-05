using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int maxHealth;
	int currentHealth;
	public EnemyHealthBar enemyHealthBar;
	public UnityEvent ondeath;

	string[] myArray = { "Armor_Bonus", "Damage_Bonus", "HP_Bonus", "Speed_Bobus" };
	//=====================
	private void OnEnable()
	{
		ondeath.AddListener(Death);
	}
	//=====================

	private void OnDisable()
	{
		ondeath.RemoveListener(Death);
	}
	//=====================

	private void Start()
	{
		currentHealth = maxHealth;
		enemyHealthBar.UpdateBar(currentHealth, maxHealth, false);
	}
	//=====================
	Transform offset ;
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		offset = gameObject.transform;
		if (currentHealth <= 0)
		{
			string randomElement = GetRandomArrayElement(myArray);

			GameObject prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bonus/"+ randomElement + ".prefab", typeof(GameObject));
			Instantiate(prefabObject, offset.position , offset.rotation);
			Debug.Log(offset);
			currentHealth = 0;
			ondeath.Invoke();
		}
	}
	//=====================
	public void Death()
	{
		Destroy(gameObject);
	}
	//=====================
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "bulletP")
		{
			TakeDamage(5);
			enemyHealthBar.UpdateBar(currentHealth, maxHealth, true);
			Destroy(collision.gameObject);
		}

		if (collision.tag == "Player")
		{
			

		}
		if (collision.tag == "BoxBound")
		{
			Destroy(gameObject);
		}
	}
	private string GetRandomArrayElement(string[] array)
	{
		System.Random random = new System.Random();
		int randomIndex = random.Next(array.Length);
		return array[randomIndex];
	}

}
