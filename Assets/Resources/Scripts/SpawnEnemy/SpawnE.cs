using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnE : MonoBehaviour
{
	[SerializeField]
	private GameObject enemy;

	private BoxCollider2D box;
	private int countEnemy;
	
	
	/*public static int ReturnCountEnemy()
	{
		return countEnemy;
	}*/
	void Start()
	{
		countEnemy = 0;
		box = GetComponent<BoxCollider2D>();
		StartCoroutine(SpawnEnemyStage1());
	}



	IEnumerator SpawnEnemyStage1()
	{
		if(countEnemy == 0)
		{
			yield return new WaitForSeconds(3f);

		}
		if (countEnemy > 0 && countEnemy <= 2)
			yield return new WaitForSeconds(7f);
		else if (countEnemy >= 3 && countEnemy <=7)
			yield return new WaitForSeconds(Random.Range(1f, 5f));

		if (countEnemy <= 7)
		{
			
			float minX = -box.bounds.size.x / 2f;
			float maxX = box.bounds.size.x / 2f;
			Vector3 temp = transform.position;
			temp.x = Random.Range(minX, maxX);
			Instantiate(enemy, temp, Quaternion.identity);
			countEnemy++;
			StartCoroutine(SpawnEnemyStage1());
		}
		PlayerPrefs.SetInt("CountEnemy", countEnemy);
	}
}
