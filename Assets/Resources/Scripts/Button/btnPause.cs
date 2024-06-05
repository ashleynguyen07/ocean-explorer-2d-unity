using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnPause : MonoBehaviour
{
	
	[SerializeField]
	GameObject panelPause;
	public void Play()
	{

		panelPause.SetActive(false);

		Time.timeScale = 1;

	}
	public void Pause()
	{
		
			panelPause.SetActive(true);
			
			Time.timeScale = 0;
		
	}
	
}
