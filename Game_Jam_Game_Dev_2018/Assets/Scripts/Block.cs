using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //private float mass;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}