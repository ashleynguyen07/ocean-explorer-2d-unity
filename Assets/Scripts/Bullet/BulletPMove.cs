using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    #region Fields 
    public float moveSpeed;
    private Rigidbody2D rb;

	#endregion
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f,moveSpeed);
        
    }
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "BoxBound")
		{
			Destroy(gameObject);
		}

	}
}
