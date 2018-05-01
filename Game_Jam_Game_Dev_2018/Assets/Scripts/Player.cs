using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Rigidbody2D blockRigidBody = null;

    [SerializeField] private float xSpeed;
    [SerializeField] private float pushForce;

    private bool readyToPush = false;

    //public Transform firepoint;
    //public GameObject pProjectile;
    //public int sliderPass;
    //public Slider selfHealth;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        GameManager.Instance.pHealth = 50;
        //sliderPass = GameManager.Instance.pHealth;
        foreach (string str in Input.GetJoystickNames())
        {
            Debug.Log(str);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(myRigidbody.velocity.y);

        //selfHealth.value = sliderPass;

        if (GameManager.Instance.pHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FixedUpdate()
    {
        //        if (Input.GetKey(KeyCode.RightArrow))
        //        {
        //           myRigidbody.velocity = new Vector2(xSpeed, myRigidbody.velocity.y);
        //            
        //        }
        //
        //       if (Input.GetKey(KeyCode.LeftArrow)) 
        //           {

        //            myRigidbody.velocity = new Vector2(-xSpeed, myRigidbody.velocity.y);

        //            } 
        //        else
        //      {
        //            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);

        //    }


        //Basic Movement for player using Rigidbody Velocity
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(moveHorizontal, moveVertical) * xSpeed);

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (readyToPush)
            {
                Debug.Log("Push Down");
                Push(-transform.up, blockRigidBody);
            }
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (readyToPush)
            {
                Debug.Log("Push Left");
                Push(-transform.right, blockRigidBody);
            }
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            if (readyToPush)
            {
                Debug.Log("Push Up");
                Push(transform.up, blockRigidBody);
            }
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (readyToPush)
            {
                Debug.Log("Push Left");
                Push(transform.right, blockRigidBody);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            myRigidbody.velocity /= 2;
        }
      //  if (Input.GetKey(KeyCode.Space))
        //{   //Creates a projectile object (from inspector specified prefab at an inspector specified location)
          //  Instantiate(pProjectile, firepoint.position, firepoint.rotation);

       /// }

    }

    public void Push(Vector2 direction, Rigidbody2D rb2d)
    {
        rb2d.velocity = direction * pushForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Debug.Log("Touch Block");
            readyToPush = true;
            blockRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Debug.Log("Untouch Block");
            readyToPush = false;
            blockRigidBody = null;
        }
    }
}
