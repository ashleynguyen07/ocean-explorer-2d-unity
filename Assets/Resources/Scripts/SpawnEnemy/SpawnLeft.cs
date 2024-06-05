using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeft : MonoBehaviour
{
	[SerializeField]
	private GameObject enemy;

	private BoxCollider2D box;
	private static int countEnemyTop;
	private bool check = true;
	private int countEnemyLeft = 0;

	void Start()
	{
		box = GetComponent<BoxCollider2D>();
		
	}
	void Update()
	{

		countEnemyTop = SpawnE.ReturnCountEnemy();
		if (check && countEnemyTop >= 2)
		{

			StartCoroutine(SpawnEnemy());
			check = false;
		}
	}

	IEnumerator SpawnEnemy()
	{

		yield return new WaitForSeconds(1f);
		if (countEnemyLeft <= 10)
		{
			countEnemyLeft++;
			Vector3 temp = transform.position;			
			  Instantiate(enemy, temp, Quaternion.identity);
		/*	EnemySpawned(newEnemy);*/
			StartCoroutine(SpawnEnemy());

		}
	}
	//========================

	/*void EnemySpawned(GameObject enemy)
	{
		// Ch?nh s?a các thu?c tính c?a enemy ? ?ây
		enemy.GetComponent<Enemyleft>().Health = 100;
	}*/
}
