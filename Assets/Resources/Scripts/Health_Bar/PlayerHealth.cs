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
	int maxHealth;
	int currentHealth;
	public PHealthBar healthBar;
	public UnityEvent ondeath;

	public Point point;
	int countEnemy;
	string win;
	int totalPoint;

	GameObject winPanel;
	GameObject gameOverPanel;
	GameObject shield;
	string checkShield;
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
		
		PlayerPrefs.SetInt("CountEnemy", 0);
		PlayerPrefs.SetInt("Point", 0);
		PlayerPrefs.SetString("Win", "false");

		winPanel = GameObject.Find("WinPanel");
		OnOffPanelWin();
		gameOverPanel = GameObject.Find("GameOverPanel");
		
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
			TakeDamage(20);
			healthBar.UpdateBar(currentHealth, maxHealth);
			Destroy(collision.gameObject);
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
			Destroy(collision.gameObject);
		}
		if (collision.tag == "Blood")
		{
			UpdateBlood();
			Destroy(collision.gameObject);
		}
		if (collision.tag == "Speed")
		{
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
		countEnemy = PlayerPrefs.GetInt("CountEnemy");
		win = PlayerPrefs.GetString("Win", "false");
		totalPoint = PlayerPrefs.GetInt("Point", 0);
		if (countEnemy == 8 && win.Equals("true") && totalPoint >= 780) StartCoroutine(WinGame());
		
	}

	IEnumerator WinGame()
	{
		yield return new WaitForSeconds(2f);
		OnOffPanelWin();
		//Application.Quit();
	}
	void OnOffPanelWin()
	{
		if (countEnemy > 6)
		{
			winPanel.SetActive(true);
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
