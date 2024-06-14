using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPosition : MonoBehaviour
{
    float positionStop;
    Rigidbody2D rb;
    void Start()
    {
		transform.rotation = Quaternion.Euler(0, 0, 180);

		positionStop =  PlayerPrefs.GetFloat("stopPosition");
        rb = GetComponent<Rigidbody2D>();

	}

    // Update is called once per frame
    void Update()
    {
        PositionStop();
    }
    void PositionStop()
    {
        if(transform.position.y < positionStop)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
