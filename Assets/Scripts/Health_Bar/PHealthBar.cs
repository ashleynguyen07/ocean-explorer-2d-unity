using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{

    public Image redBar;
    public TextMeshProUGUI valueText;

    

    // Update is called once per frame
    public void UpdateBar(int currentValue , int maxValue)
    {
			redBar.fillAmount = (float)currentValue / (float)maxValue;

			valueText.text = currentValue.ToString() + "/" + maxValue.ToString();
			
    }
}
