using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Opacity : MonoBehaviour
{
	private Image image;
	TextMeshProUGUI text;
	float startTime, opacity;
	bool check;
	private void Start()
	{
		if (GetComponent<TextMeshProUGUI>() != null)
			text = GetComponent<TextMeshProUGUI>();
		else image = GetComponent<Image>();
		opacity = 1f;
		check = true;
		startTime = 0.8f*Time.deltaTime;
	}

	private void Update()
	{
		if (opacity > 0 && check == true)
			opacity -= startTime;
		else check = false;
		if (image != null)
		{
			if (check == true)
			{
				image.color = new Color(image.color.r, image.color.g, image.color.b, opacity);
			}
			else
			{
				opacity = 1f;
				check = true;
				image.color = new Color(image.color.r, image.color.g, image.color.b, opacity);
			}
		}
		else
		{
			if (check == true)
			{
				text.color = new Color(text.color.r, text.color.g, text.color.b, opacity);
			}
			else
			{
				opacity = 1f;
				check = true;
				text.color = new Color(text.color.r, text.color.g, text.color.b, opacity);
			}
		}
	}
}
