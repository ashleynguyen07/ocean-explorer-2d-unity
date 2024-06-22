using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	SaveData saveData;
	GameData gameData;
	public void ChangeScene(string sceneName)
	{
		saveData = new SaveData();
		gameData = saveData.LoadGame();

		if (gameData != null)
		{
			PlayerPrefs.SetString("ShipFight", gameData.shipFight);
			PlayerPrefs.SetString("childFight", gameData.childFight);
			PlayerPrefs.SetString("BulletFight", gameData.bulletFight);
			SceneManager.LoadScene("level" + gameData.level);
		}
		else
		{
			Time.timeScale = 1.0f;
			SceneManager.LoadScene(sceneName);
		}
	}
}
