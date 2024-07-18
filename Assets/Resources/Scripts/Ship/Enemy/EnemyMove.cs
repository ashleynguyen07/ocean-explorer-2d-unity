using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.AxisState;

public class EnemyMove : MonoBehaviour
{
	float maxY, y;
	public float SpeedMove;
	int stage;
	[SerializeField]
    EnemyHealthBar enemyHealthBar;
    [SerializeField]
    GameObject parentObj;
    int maxHeal;
	Rigidbody2D rb;
	bool callOneTime;
	bool callOneTiameAutoRo;

    void Start()
	{
		Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		stage = PlayerPrefs.GetInt("Stage", 1);
		callOneTime = callOneTiameAutoRo= true;
		if (stage == 1)
		{
			maxY = bounds.y - Random.RandomRange(1, 8);
		}
		else if (stage == 4)
		{
			maxY = bounds.y - 10f;
		}
		else if (stage == 5)
		{
            maxHeal = enemyHealthBar.GetCurrentHealth();
            maxY = bounds.y - 5f;
        }
		else if (stage == 6 || stage == 7)
		{
            maxHeal = enemyHealthBar.GetCurrentHealth();
            maxY = bounds.y ;
		}
		y = bounds.y;
    }
	void Update()
	{
        Enemy_Move();
    }
	//======================
	void Enemy_Move()
	{
		if (transform.position.y <= maxY && callOneTime )
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
			callOneTime=false;
        }
		else if (transform.position.y > maxY)
		{
			y -= SpeedMove * Time.deltaTime;
			transform.position = new Vector3(transform.position.x, y, 0f);
		}
		else if(stage == 5)
		{
			if (enemyHealthBar.GetCurrentHealth() <= (50 * maxHeal / 100) && callOneTiameAutoRo)
			{
				rb = parentObj.GetComponent<Rigidbody2D>();
                rb.angularVelocity = 180f;
                callOneTiameAutoRo = false;
            }
		}
        else if (stage == 6)
        {
            if (enemyHealthBar.GetCurrentHealth() <= (50 * maxHeal / 100) && callOneTiameAutoRo)
            {
                rb = parentObj.GetComponent<Rigidbody2D>();
                rb.angularVelocity = 180f;
                callOneTiameAutoRo = false;
				StartCoroutine(StopRot());
            }
        }
    }
	IEnumerator StopRot()
	{
		yield return new WaitForSeconds(1.02f);
        rb.angularVelocity = 0f;
    }
	
}
