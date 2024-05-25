using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnE : MonoBehaviour
{
    [SerializeField]
    private GameObject  enemy;

    private BoxCollider2D box;
    private int countEnemy = 0;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnEnemy());
    }

   

    IEnumerator SpawnEnemy()
    {
     
		yield return new WaitForSeconds(Random.Range(0f, 3f));
		
		if (countEnemy <= 6)
        {
			countEnemy++;
			float minX = -box.bounds.size.x / 2f;
            float maxX = box.bounds.size.x / 2f;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            Instantiate(enemy, temp, Quaternion.identity);
			StartCoroutine(SpawnEnemy());
		}
		

	}
}
