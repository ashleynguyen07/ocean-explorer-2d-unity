using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScro : MonoBehaviour
{
    float speed =0;
    Transform offset;
   

    
    void Update()
    {
        Rota();

	}
	private void Rota()
	{
        speed = 10 *Time.deltaTime; 
	    transform.Rotate(0, 0, speed);
	}

}
