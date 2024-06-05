using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBackGround : MonoBehaviour
{
	#region Fields
    private float minX, minY, maxX, maxY;
	#endregion
	// Start is called before the first frame update
	void Start()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        minX = -bounds.x +1.3f;
        minY = -bounds.y + 2;
        maxX = bounds.x - 1.3f;
        maxY = bounds.y-1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = transform.position;
        if(tmp.x < minX)
        {
            tmp.x = minX;
        }else if(tmp.x > maxX)
        {
            tmp.x = maxX;
        }
        if(tmp.y < minY)
        {
            tmp.y = minY;
        }
        if(tmp.y > maxY)
        {
            tmp.y = maxY;
        }

        transform.position = tmp;
    }
}
