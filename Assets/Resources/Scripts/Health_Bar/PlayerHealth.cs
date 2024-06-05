using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public PHealthBar healthBar;
    public UnityEvent ondeath;

	public Point point;
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
		point.UpdatePoint(5);
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
		if (collision.tag == "bulletE")
		{
			
			TakeDamage(1);
			healthBar.UpdateBar(currentHealth, maxHealth);
			Destroy(collision.gameObject);
		}
		if (collision.tag == "shield")
		{
			Destroy(collision.gameObject);

		}
		if (collision.tag == "Damage")
		{
			Destroy(collision.gameObject);

		}
		if (collision.tag == "Blood")
		{
			Destroy(collision.gameObject);

		}
		if (collision.tag == "Speed")
		{
			Destroy(collision.gameObject);

		}
	}

}
