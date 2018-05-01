using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Rigidbody2D blockRigidBody = null;
    private Animator anim;

    [SerializeField] private float xSpeed;
    [SerializeField] private float pushForce;

    private bool readyToPush = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Basic Movement for player using Rigidbody Velocity
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(moveHorizontal != 0 || moveVertical != 0)
        {
            anim.SetBool("Moving", true);
        }

        else
        {
            anim.SetBool("Moving", false);
        }

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

    }

    public void Push(Vector2 direction, Rigidbody2D rb2d)
    {
        rb2d.velocity = direction * pushForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ReflectiveSurface")
        {
            Debug.Log("Touch Block");
            readyToPush = true;
            blockRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ReflectiveSurface")
        {
            Debug.Log("Untouch Block");
            readyToPush = false;
            blockRigidBody = null;
        }
    }
}