using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public bool BlockWinLocal;
    public AudioSource CollisionNoise;
    public AudioClip BlockCollision;
    public AudioClip WallCollision;

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
            CollisionNoise.PlayOneShot(WallCollision);
            
        }
       
        if(collision.gameObject.tag == "ReflectiveSurface")
        {
            rb2d.velocity = Vector2.zero;
            CollisionNoise.PlayOneShot(BlockCollision);
        }
        if (collision.gameObject.tag != "BlockSwitch" || collision.gameObject.tag == "LaserSwitch")
        {
            Vector3 currentPos = transform.position;
            transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y));
        }
        if(collision.gameObject.tag == "BlockSwitch" )
        {
            GameManager.Instance.Level1BlocksPlaced = (GameManager.Instance.Level1BlocksPlaced + 1);
            Debug.Log(GameManager.Instance.Level1BlocksPlaced);
            BlockWinLocal = true;
            

        }

    }
}