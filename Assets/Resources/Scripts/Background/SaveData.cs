using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveData : MonoBehaviour
{
	private string saveFilePath;
	private string saveFilePathMeta;
	public void SaveGame(GameData gameData)
	{
		saveFilePath = Application.dataPath + "/gamedata.json";
		string saveData = JsonUtility.ToJson(gameData);
		File.WriteAllText(saveFilePath, saveData);
	}
	public GameData LoadGame()
	{
		saveFilePath = Application.dataPath + "/gamedata.json";
		GameData loadedData;
		if (File.Exists(saveFilePath))
		{
			string saveData = File.ReadAllText(saveFilePath);
			loadedData = JsonUtility.FromJson<GameData>(saveData);
		}
		else
		{
			loadedData = null;
		}
		return loadedData;
	}
	public void DeleteSavedData()
	{
		saveFilePath = Application.dataPath + "/gamedata.json";
		saveFilePathMeta = Application.dataPath + "/gamedata.json.meta";
		if (File.Exists(saveFilePath))
		{
			try
			{
				File.Delete(saveFilePath);
				File.Delete(saveFilePathMeta);
			}
			catch (System.Exception e)
			{
				Debug.LogError($"Error delete: {e.Message}");
			}
		}
	}
}
[System.Serializable]
public class GameData
{
	public float score;
	public float lives;
	public string shipFight;
	public string bulletFight;
	public string childFight;
	public int stage;
	public int level;
	public int countRocket;
	public int countSpeed;
	public int damage;
	public float speed;
	public Vector3 playerPosition;
}