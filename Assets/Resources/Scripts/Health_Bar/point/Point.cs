using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
	public TextMeshProUGUI valueTextPoint;

	int totalPoint=0;
    
    public void UpdatePoint(int point)
    {
		totalPoint += point;
		valueTextPoint.text = "Point :" + totalPoint.ToString();
		PlayerPrefs.SetInt("Point", totalPoint);
	}
}
