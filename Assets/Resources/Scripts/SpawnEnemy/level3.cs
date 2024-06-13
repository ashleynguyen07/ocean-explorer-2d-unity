using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class level3 : MonoBehaviour
{
	[SerializeField]
	private GameObject enemy;
	Rigidbody2D rb;
	GameObject enemy2;
	GameObject meteo;

	private BoxCollider2D box;
	private int countEnemy;
	float minX, maxX, maxY, speed;


	void Start()
	{

		Vector3 bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		enemy2 = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/Enemy/enemy-6.prefab", typeof(GameObject));

		meteo = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bullet/Meteor_01.prefab", typeof(GameObject));


		countEnemy = 0;
		minX = -bound.x;
		maxX = bound.x;
		maxY = bound.y - 10f;
		speed = 2f;

		box = GetComponent<BoxCollider2D>();

		StartCoroutine(SpawnStageMeteo());
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
			Instantiate(enemy, temp, Quaternion.identity);
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

			GameObject enemyTmp = Instantiate(enemy2, temp, Quaternion.identity);

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

			GameObject enemyTmp = Instantiate(enemy2, temp, Quaternion.identity);
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
			Vector3 temp = new Vector3(2, 2, 0);

			Instantiate(enemy2, temp, Quaternion.identity);
			countEnemy++;
			StartCoroutine(SpawnEnemyStage3());
		}
	}
	IEnumerator SpawnStageMeteo()
	{
		
			yield return new WaitForSeconds(2f);
			
				Vector3 temp = transform.position;
				temp.x = Random.Range((minX+0.2f), (maxX-0.2f));

				Instantiate(meteo, temp, Quaternion.identity);
				countEnemy++;
				StartCoroutine(SpawnStageMeteo());
			
		
	}
}
