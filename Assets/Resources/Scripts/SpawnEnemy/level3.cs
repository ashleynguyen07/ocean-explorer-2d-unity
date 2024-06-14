using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class level3 : MonoBehaviour
{
	
	Rigidbody2D rb;
	GameObject enemy1, enemy2, enemy3, childBoss, boss, enemyTest, enemyTest2;
	GameObject meteo;

	private BoxCollider2D box;
	private int countEnemy;
	float minX, maxX, maxY, speed;
	string randomMeteor;

	string[] meteors = { "Meteor_01", "Meteor_02", "Meteor_03", "Meteor_04", "Meteor_05" };
	void Start()
	{

		Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

		enemy1 = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Enemy/Enemy-1.prefab", typeof(GameObject));
		enemy2 = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Enemy/Enemy-2.prefab", typeof(GameObject));
		enemy3 = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Enemy/Enemy-3.prefab", typeof(GameObject));
		childBoss = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Enemy/EnemyChildBoss1.prefab", typeof(GameObject));
		boss = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Enemy/EnemyBoss.prefab", typeof(GameObject));
		enemyTest = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Enemy/enemy-5.prefab", typeof(GameObject));
		enemyTest2 = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Enemy/enemy-6.prefab", typeof(GameObject));
		countEnemy = 0;
		minX = -bound.x;
		maxX = bound.x;
		Debug.Log(minX + " " + maxX);
		maxY = bound.y - 9f;
		speed = 2f;

		box = GetComponent<BoxCollider2D>();
		randomMeteor = GetRandomArrayElement(meteors);
		StartCoroutine(SpawnEnemyStage1());
		//StartCoroutine(SpawnEnemyStage2_1());

	}

	private string GetRandomArrayElement(string[] array)
	{
		System.Random random = new System.Random();
		int randomIndex = random.Next(array.Length);
		return array[randomIndex];
	}
	IEnumerator SpawnEnemyStage1()
	{
		if (countEnemy == 0)
		{
			yield return new WaitForSeconds(3f);
		}
		if (countEnemy > 0 && countEnemy <= 2)
			yield return new WaitForSeconds(7f);
		else if (countEnemy >= 3 && countEnemy <= 7)
			yield return new WaitForSeconds(Random.Range(1f, 5f));

		if (countEnemy <= 7)
		{
			Vector3 temp = transform.position;
			temp.x = Random.Range(minX, maxX);
			Instantiate(enemy1, temp, Quaternion.identity);
			countEnemy++;
			StartCoroutine(SpawnEnemyStage1());
		}
		else
		{
			StartCoroutine(SpawnEnemyStage2());
		}
	}

	IEnumerator SpawnEnemyStage2()
	{
		if (countEnemy < 3)
		{
			yield return new WaitForSeconds(2f);

			Vector3 temp = transform.position;
			temp.x = minX + 2f;
			maxY += 2f;
			PlayerPrefs.SetFloat("stopPosition", maxY);

			GameObject enemyTmp = Instantiate(enemyTest, temp, Quaternion.identity);

			rb = enemyTmp.AddComponent<Rigidbody2D>();
			rb.velocity = new Vector2(+1, -1);
			rb.gravityScale = 0f;

			countEnemy++;
			StartCoroutine(SpawnEnemyStage2());
		}
	}
	IEnumerator SpawnEnemyStage2_1()
	{
		if (countEnemy < 3)
		{
			yield return new WaitForSeconds(2f);
			Vector3 temp = transform.position;
			temp.x = maxX - 2f;

			GameObject enemyTmp = Instantiate(enemyTest, temp, Quaternion.identity);
			rb = enemyTmp.AddComponent<Rigidbody2D>();

			rb.velocity = new Vector2(-1, -1);
			rb.gravityScale = 0f;

			StartCoroutine(SpawnEnemyStage2_1());
		}
	}
	IEnumerator SpawnEnemyStage3()
	{
		if (countEnemy < 6)
		{
			yield return new WaitForSeconds(1f);
			Vector3 temp = new Vector3(4, 12, 0);

			Instantiate(enemyTest2, temp, Quaternion.identity);
			countEnemy++;
			StartCoroutine(SpawnEnemyStage3());
		}
	}
	IEnumerator SpawnStageMeteo()
	{
		meteo = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/" + randomMeteor + ".prefab", typeof(GameObject));
		yield return new WaitForSeconds(2f);
		if (countEnemy < 3)
		{
			Vector3 temp = transform.position;
			temp.x = Random.Range((minX + 0.2f), (maxX - 0.2f));

			Instantiate(meteo, temp, Quaternion.identity);
			countEnemy++;
			StartCoroutine(SpawnStageMeteo());
		}

	}
	IEnumerator SpawnStageChildBoss()
	{
		
		yield return new WaitForSeconds(2f);
		if (countEnemy < 1)
		{
			Vector3 temp = transform.position;
			temp.x = 3;

			Instantiate(childBoss, temp, Quaternion.identity);
			countEnemy++;
			StartCoroutine(SpawnStageMeteo());
		}

	}
	IEnumerator SpawnStageBoss()
	{

		yield return new WaitForSeconds(2f);
		if (countEnemy < 1)
		{
			Vector3 temp = transform.position;
			temp.x = 3;

			Instantiate(boss, temp, Quaternion.identity);
			countEnemy++;
			StartCoroutine(SpawnStageMeteo());
		}

	}
}
