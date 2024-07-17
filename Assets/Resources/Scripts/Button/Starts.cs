using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
    SaveData saveData;

    public void ChangeScene(string sceneName)
    {
        saveData = new SaveData();
        saveData.DeleteSavedData();
        Time.timeScale = 1.0f;

        if (sceneName.Equals("Reset"))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Start");
        }
        else if (sceneName.Equals("level1"))
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName.Equals("level2") && (PlayerPrefs.GetInt("Win") == 1 || PlayerPrefs.GetInt("Win") == 3))
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName.Equals("level3") && (PlayerPrefs.GetInt("Win") == 2 || PlayerPrefs.GetInt("Win") == 3))
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (!sceneName.Equals("level1") && !sceneName.Equals("level2") && !sceneName.Equals("level3"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
