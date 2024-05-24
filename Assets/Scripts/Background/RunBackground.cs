using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBackground : MonoBehaviour
{
    #region Fields
    public float speedScroll;
    private Vector2 offset = Vector2.zero;
    private Material material;



	#endregion
	void Start()
    {
        var woldHeight = Camera.main.orthographicSize *2f;

        var woldWidth = woldHeight * Screen.width/Screen.height;

        transform.localScale = new Vector3(woldWidth, woldHeight,0f);
        //==================
        material = GetComponent<Renderer>().material;

        offset = material.GetTextureOffset("_MainTex");
        
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += speedScroll * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
