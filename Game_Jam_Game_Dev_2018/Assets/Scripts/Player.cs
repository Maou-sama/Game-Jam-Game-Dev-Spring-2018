using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float xSpeed = .4f;
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

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        myRigidbody.velocity = movement * xSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            myRigidbody.velocity /= 2;
        }
      //  if (Input.GetKey(KeyCode.Space))
        //{   //Creates a projectile object (from inspector specified prefab at an inspector specified location)
          //  Instantiate(pProjectile, firepoint.position, firepoint.rotation);

       /// }

    }

}
