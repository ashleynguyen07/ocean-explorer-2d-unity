using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField]
	int maxHealth,maxPower;
	
	public PHealthBar healthBar;
	public Power power;
	public UnityEvent ondeath;

	public Point point;
	float speed , currentPower;
	string win, checkShield;
	int totalPoint,damage, countEnemy, currentHealth ;

	GameObject winPanel, gameOverPanel, shield;
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
		currentPower = 0f;
		power.UpdatePower(currentPower, maxPower);
		currentHealth = maxHealth;
		healthBar.UpdateBar(currentHealth, maxHealth);
		PlayerPrefs.SetInt("Point", 0);
		PlayerPrefs.SetInt("damage", 0);
		PlayerPrefs.SetFloat("Speed", 1f);
		PlayerPrefs.SetString("shieldP", "false");
		winPanel = GameObject.Find("WinPanel");
		OnOffPanelWin();
		gameOverPanel = GameObject.Find("GameOverPanel");
		speed = damage = 0;
		gameOverPanel.SetActive(false);
		
	}
	//=====================
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
		
			currentHealth = 0;
			ondeath.Invoke();
			OnPanelGameOver();
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
			checkShield = PlayerPrefs.GetString("shieldP");
			if (checkShield.Equals("false"))
			{
				TakeDamage(1);
				healthBar.UpdateBar(currentHealth, maxHealth);
				Destroy(collision.gameObject);
			}
		}
		if (collision.tag == "enemy")
		{
			checkShield = PlayerPrefs.GetString("shieldP");
			if (checkShield.Equals("false"))
			{
				TakeDamage(5);
				healthBar.UpdateBar(currentHealth, maxHealth);
			}
		}
		if (collision.tag == "shield")
		{
			Shield();
			Destroy(collision.gameObject);
		}
		if (collision.tag == "Damage")
		{
			damage += 3;
			PlayerPrefs.SetInt("damage", damage);
			Destroy(collision.gameObject);
		}
		if (collision.tag == "Blood")
		{
			UpdateBlood();
			Destroy(collision.gameObject);
		}
		if (collision.tag == "Speed")
		{
			PlayerPrefs.SetFloat("Speed", 0.5f);
			Destroy(collision.gameObject);
		}
		if (collision.tag == "diamond")
		{
			point.UpdatePoint(5);
			Destroy(collision.gameObject);
		}
	}
	private void Update()
	{
		power.UpdatePower(10*Time.deltaTime, maxPower);
		totalPoint = PlayerPrefs.GetInt("Point", 0);
		//if ( totalPoint >= 780) StartCoroutine(WinGame());
		
	}

	IEnumerator WinGame()
	{
		
		yield return new WaitForSeconds(2f);
		Time.timeScale = 0f;
		OnOffPanelWin();
		//Application.Quit();
	}
	void OnOffPanelWin()
	{
		if (totalPoint > 600)
		{
			winPanel.SetActive(true);
			PlayerPrefs.SetString("level1", "true");
		    StartCoroutine(ReturnMapScene());
		}
		else winPanel.SetActive(false);
	}

	void OnPanelGameOver()
	{
		Time.timeScale = 0f;
		gameOverPanel.SetActive(true);
	}
	IEnumerator ReturnMapScene()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("Map");
	}

	private void UpdateBlood()
	{
		currentHealth = 100;
		healthBar.UpdateBar(currentHealth, maxHealth);
	}
	private void Shield()
	{
		shield = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefaps/bonus/shield.prefab", typeof(GameObject));
		Instantiate(shield, gameObject.transform.position, gameObject.transform.rotation);
		PlayerPrefs.SetString("shieldP", "true");
	}


}
