using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyE : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BottomBoxBound")
        {
            Destroy(gameObject);
        }
    }
}
