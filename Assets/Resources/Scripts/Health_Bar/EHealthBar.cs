using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthBar : MonoBehaviour
{
	public Image redBar;
	public void UpdateBar(int currentValue, int maxValue, bool status)
	{
        if (status == true)
        {
			gameObject.SetActive(true);
			redBar.fillAmount = (float)currentValue / (float)maxValue;
			StartCoroutine( EHealthApprean());
		}
		else
		{
			redBar.fillAmount = (float)currentValue / (float)maxValue;
		}
	}
	IEnumerator EHealthApprean()
	{
		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
	}
}
