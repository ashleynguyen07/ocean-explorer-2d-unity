using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffPanel : MonoBehaviour
{
	bool onOff = false;
	[SerializeField]
	 GameObject popupPanel;
	public void btnOnOffPanel()
	{
		if (onOff !=true)
		{
			onOff = true;
			popupPanel.SetActive(true);
		}
		else
		{
			onOff = false;
			popupPanel.SetActive(false);
		}

	}
}
