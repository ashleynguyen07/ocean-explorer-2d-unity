using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxHealth;
    int currentHealth;

    public HealthBar healthBar;

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
        healthBar.UpdateBar(currentHealth, maxHealth);

	}
	//=====================

	public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
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
		if (collision.tag == "bulletE")
		{
			
			TakeDamage(1);
			healthBar.UpdateBar(currentHealth, maxHealth);
			Destroy(collision.gameObject);
		}
	}

}
