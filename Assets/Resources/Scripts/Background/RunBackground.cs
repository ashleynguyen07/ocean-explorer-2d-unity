using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBackground : MonoBehaviour
{
    #region Fields
     
    private Vector2 offset = Vector2.zero;
    private Material material;

    float speedtmp, speedScroll;

	#endregion
	void Start()
    {
        var woldHeight = Camera.main.orthographicSize *2f;
        speedScroll = 0.2f;

		var woldWidth = woldHeight * Screen.width/Screen.height;

        transform.localScale = new Vector3(woldWidth, woldHeight,0f);
        //==================
        material = GetComponent<Renderer>().material;

        offset = material.GetTextureOffset("_MainTex");
        
    }

    // Update is called once per frame
    void Update()
    {
       speedtmp = PlayerPrefs.GetFloat("Speed");
        offset.y += (speedScroll+speedtmp*0.2f) * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
