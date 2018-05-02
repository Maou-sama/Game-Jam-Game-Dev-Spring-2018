using UnityEngine;
using System.Collections;

public class RotateLaser : MonoBehaviour
{
    [Header("Rotational Velocity of Laser")]
    [SerializeField] private float rotateVelocity;

    private bool rotatable = false;

    private void Update()
    {
        if (rotatable)
        {
            if (Input.GetKey(KeyCode.U))
            {
                Debug.Log("Rotate Left");
                if (Input.GetKey(KeyCode.LeftShift)){
                    transform.Rotate(transform.forward, rotateVelocity * 10);
                }
                else {
                    transform.Rotate(transform.forward, rotateVelocity);
                }
            }

            else if (Input.GetKey(KeyCode.O))
            {
                Debug.Log("Rotate Right");
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Rotate(transform.forward, -rotateVelocity * 10);
                }
                else
                {
                    transform.Rotate(transform.forward, -rotateVelocity);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rotatable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rotatable = false;
        }
    }
}
