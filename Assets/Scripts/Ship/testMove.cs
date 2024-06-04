using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    [SerializeField]
   

    public float speedMove;
    float y, x, minX, maxX;

    
    void Start()
    {
        Vector3 bound = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, 0));
        
        minX = -bound.x +0.5f;
        maxX = bound.x -0.5f;
      
       transform.position = new Vector3(0f,0f,0f);
        x= transform.position.x;
       StartCoroutine( Move());


    }

	// Update is called once per frame

	 IEnumerator Move()
	{
		  while (x< (3*Mathf.PI))
        {
            yield return new WaitForSeconds(0.01f);
            x += speedMove* Time.deltaTime;
            y = Mathf.Sin(x);
            
            transform.position = new Vector3 (x,y,0f);    
        }


	
	}



}
