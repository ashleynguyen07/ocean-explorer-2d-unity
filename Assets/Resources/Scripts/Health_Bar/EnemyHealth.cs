using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int maxHealth;
	int currentHealth;

	public EnemyHealthBar enemyHealthBar;

	public UnityEvent ondeath;

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

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
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

}
