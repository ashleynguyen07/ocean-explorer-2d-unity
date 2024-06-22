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
	GameObject prefabDiamond;
	string[] myArray = { "Armor_Bonus", "Damage_Bonus", "HP_Bonus", "Speed_Bobus", "Rockets_Bonus" };
	int countDiamond = 0;
	private void OnEnable()
	{
		ondeath.AddListener(Death);
	}
	private void OnDisable()
	{
		ondeath.RemoveListener(Death);
	}
	private void Start()
	{
		currentHealth = maxHealth;
		enemyHealthBar.UpdateBar(currentHealth, maxHealth, false);
	}
	Transform offset ;
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		offset = gameObject.transform;
		if (currentHealth <= 0)
		{
			//============= sinh diamond ====================
			prefabDiamond = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bonus/diamond.prefab", typeof(GameObject));
			StartCoroutine(SpawnDiamond());
			//============= sinh Bonus ====================
			string randomElement = GetRandomArrayElement(myArray);
			GameObject prefabObject = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bonus/"+ randomElement + ".prefab", typeof(GameObject));
			Instantiate(prefabObject, offset.position , offset.rotation);
			//======== call death ===============
			currentHealth = 0;
			ondeath.Invoke();
		}
	}
	public void Death()
	{
		Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "bulletP")
		{
			int damage = PlayerPrefs.GetInt("damage",0);
			TakeDamage(50+damage);
			enemyHealthBar.UpdateBar(currentHealth, maxHealth, true);
			Destroy(collision.gameObject);
		}
		if (collision.tag == "Player")
		{
			if(collision.tag == "shieldP")
			{
				TakeDamage(20);
				enemyHealthBar.UpdateBar(currentHealth, maxHealth, true);
			}
		}
		if (collision.tag == "PlayerExtra"|| collision.tag == "BulletExtra")
		{
			TakeDamage(1);
			enemyHealthBar.UpdateBar(currentHealth, maxHealth, true);
		}
		if (collision.tag == "BoxBound")
		{
			Destroy(gameObject);
		}
		if (collision.tag == "BulletRocket")
		{
			TakeDamage(50 );
			enemyHealthBar.UpdateBar(currentHealth, maxHealth, true);
			Destroy(collision.gameObject);
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.tag == "PlayerExtra" || collision.tag == "BulletExtra")
		{
			TakeDamage(1);
			enemyHealthBar.UpdateBar(currentHealth, maxHealth, true);
		}
	}
	private string GetRandomArrayElement(string[] array)
	{
		System.Random random = new System.Random();
		int randomIndex = random.Next(array.Length);
		return array[randomIndex];
	}
	IEnumerator  SpawnDiamond()
	{
		countDiamond++;
		if(countDiamond <= 5)
		{
			Vector3 diamondPosition = new Vector3(offset.position.x + Random.Range(0f, 2f), offset.position.y + Random.Range(0f, 2f), 0f);
			Instantiate(prefabDiamond, diamondPosition, offset.rotation);
			StartCoroutine(SpawnDiamond());
		}
		yield return null;
	}
}
