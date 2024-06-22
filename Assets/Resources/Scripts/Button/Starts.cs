using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
	SaveData saveData;
	GameData gameData;
	public void ChangeScene(string sceneName)
	{
		gameData = saveData.LoadGame();
		if (gameData != null)
		{
			saveData = new SaveData();
			saveData.DeleteSavedData();
			Debug.Log("gamedata null");
		}
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(sceneName);
	}
}
