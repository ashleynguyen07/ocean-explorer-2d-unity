using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
	
	public void ChangeScene(string sceneName)
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(sceneName);
	}
}
