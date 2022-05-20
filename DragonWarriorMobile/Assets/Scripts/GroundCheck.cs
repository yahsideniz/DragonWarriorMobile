using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision) // colliderlar i� i�e girdiyse
    {
        if (collision.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // collider digerinden c�kt�ysa
    {
        if (collision.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
