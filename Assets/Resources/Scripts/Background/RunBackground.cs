using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBackground : MonoBehaviour
{
    #region Fields
     
    private Vector2 offset = Vector2.zero;
    private Material material;

    float speedtmp,timeSpeed;
    int i;
    bool check;
	#endregion
	void Start()
    {
        var woldHeight = Camera.main.orthographicSize *2f;
        
        i = 0;
		var woldWidth = woldHeight * Screen.width/Screen.height;

        transform.localScale = new Vector3(woldWidth, woldHeight,0f);
        //==================
        material = GetComponent<Renderer>().material;

        offset = material.GetTextureOffset("_MainTex");
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
		if (speedtmp != PlayerPrefs.GetFloat("Speed"))
		{
			speedtmp = PlayerPrefs.GetFloat("Speed");
			check = true;
		}
		if (i < 3 && check)
        {
            timeSpeed += speedtmp;
            i++;
			check = false;
		}
		offset.y += timeSpeed*0.3f * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
