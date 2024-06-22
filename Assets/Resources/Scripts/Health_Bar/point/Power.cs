using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
	public Image powerElement;
	float tmpPower;
	public void UpdatePower(float currentValue, int maxValue)
	{
		if(currentValue == 0) tmpPower = 0;
		if (tmpPower >= maxValue)
		{
			tmpPower = 100;
			PlayerPrefs.SetFloat("Power", tmpPower);
		}
		else 
		{
			tmpPower += currentValue;
			PlayerPrefs.SetFloat("Power", tmpPower);
		}
		powerElement.fillAmount = tmpPower / (float)maxValue;
	}
}
