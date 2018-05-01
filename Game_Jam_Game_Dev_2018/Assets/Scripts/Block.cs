using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Concrete")
        {
            Debug.Log("Touched Wall");
            rb2d.velocity = Vector2.zero;
        }

        if(collision.gameObject.tag == "ReflectiveSurface")
        {
            rb2d.velocity = Vector2.zero;
        }

        Vector3 currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y));
    }
}