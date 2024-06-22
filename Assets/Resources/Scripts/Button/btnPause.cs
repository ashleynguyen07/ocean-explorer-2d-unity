using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnPause : MonoBehaviour
{

	[SerializeField]
	GameObject panelPause;
	GameData gameData;
	SaveData saveData;
	public void Play()
	{
		panelPause.SetActive(false);
		Time.timeScale = 1;
		saveData = new SaveData();
		saveData.DeleteSavedData();
	}
	public void Pause()
	{
		panelPause.SetActive(true);
		Time.timeScale = 0;
		gameData = new GameData
		{
			score = PlayerPrefs.GetInt("Point"),
			lives = PlayerPrefs.GetFloat("Health"),

			shipFight = PlayerPrefs.GetString("ShipFight"),
			bulletFight = PlayerPrefs.GetString("BulletFight"),
			childFight = PlayerPrefs.GetString("ChildFight"),

			stage = PlayerPrefs.GetInt("Stage"),
			level = PlayerPrefs.GetInt("Level"),
			playerPosition = new Vector3(2f, 3f, 0f),

			countRocket = PlayerPrefs.GetInt("CountRocket"),
			countSpeed = PlayerPrefs.GetInt("CountSpeed"),
			damage = PlayerPrefs.GetInt("damage"),

			speed = PlayerPrefs.GetFloat("Speed")
		};
		saveData = new SaveData();
		saveData.SaveGame(gameData);
	}
}
