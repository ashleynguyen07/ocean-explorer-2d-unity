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
	int maxHealth, maxPower;

	public PHealthBar healthBar;
	public Power power;
	public UnityEvent ondeath;

	public Point point;
	float speedBonus, currentPower;
	string  checkShield;
	int totalPoint, damage, currentHealth, timeBonusSpeed, countRocket, countSpeed;

	GameObject winPanel, gameOverPanel, shield;
	SaveData saveData;
	GameData gameData;

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
		speedBonus = currentPower = 0f;
		countSpeed = countRocket = timeBonusSpeed = damage = 0;
		power.UpdatePower(currentPower, maxPower);

		currentHealth = maxHealth;
		healthBar.UpdateBar(currentHealth, maxHealth);

		PlayerPrefs.SetInt("ThreeRoket", 0);
		PlayerPrefs.SetInt("Roket", 0);
		PlayerPrefs.SetInt("Point", 0);
		PlayerPrefs.SetInt("damage", 0);
		PlayerPrefs.SetFloat("Speed", 0.5f);
		PlayerPrefs.SetString("shieldP", "false");

		saveData = new SaveData();
		gameData = saveData.LoadGame();
		if (gameData != null)
		{
			int stage = gameData.stage;
			if (stage == 2)
			{
				SetGameData();
				point.UpdatePoint(800);
			}
			else if (stage == 3)
			{
				SetGameData();
				point.UpdatePoint(2300);
			}
			else if (stage == 4)
			{
				SetGameData();
				point.UpdatePoint(1500);
			}
			else if (stage == 5)
			{
				SetGameData();
				point.UpdatePoint(1400);
			}
			else if (stage == 6)
			{
				SetGameData();
				point.UpdatePoint(2900);
			}
		}
		gameOverPanel = GameObject.Find("GameOverPanel");
		winPanel = GameObject.Find("WinPanel");
		OnOffPanelWin();
		gameOverPanel.SetActive(false);
	}
	private void SetGameData()
	{
		healthBar.UpdateBar((int)gameData.lives, maxHealth);
		countRocket = gameData.countRocket;
		countSpeed = gameData.countSpeed;
		if (countSpeed == 3 || countRocket == 3) PlayerPrefs.SetInt("ThreeRoket", 1);
		PlayerPrefs.SetInt("damage", gameData.damage);
		PlayerPrefs.SetFloat("Speed", gameData.speed);
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
		int extra = PlayerPrefs.GetInt("SpeedExtra", 0);

		if (extra == 0)
		{
			if (collision.tag == "bulletE")
			{
				checkShield = PlayerPrefs.GetString("shieldP");
				if (checkShield.Equals("false"))
				{
					TakeDamage(3);
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
				if (timeBonusSpeed <= 5)
				{
					timeBonusSpeed++;
					countSpeed++;
					speedBonus += PlayerPrefs.GetFloat("Speed", 0f);
					PlayerPrefs.SetFloat("Speed", speedBonus);
					PlayerPrefs.SetInt("CountSpeed", countSpeed);
				}
				if (countSpeed == 3)
				{
					PlayerPrefs.SetInt("ThreeRoket", 1);
				}
				Destroy(collision.gameObject);
			}
			if (collision.tag == "diamond")
			{
				point.UpdatePoint(20);
				Destroy(collision.gameObject);
			}
			if (collision.tag == "Rocket")
			{
				countRocket++;
				PlayerPrefs.SetInt("Roket", 1);
				PlayerPrefs.SetInt("CountRocket", countRocket);
				if (countRocket == 3)
				{
					PlayerPrefs.SetInt("ThreeRoket", 1);
				}
				Destroy(collision.gameObject);
			}
		}
	}
	private void Update()
	{
		power.UpdatePower(10 * Time.deltaTime, maxPower);
		totalPoint = PlayerPrefs.GetInt("Point", 0);
		if ( totalPoint >= 2950) StartCoroutine(WinGame());
	}
	IEnumerator WinGame()
	{
		yield return new WaitForSeconds(1f);
		Time.timeScale = 0f;
		OnOffPanelWin();
	}
	void OnOffPanelWin()
	{
		if (totalPoint > 600)
		{
			winPanel.SetActive(true);
			saveData.DeleteSavedData();
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
		yield return new WaitForSeconds(2f);
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
