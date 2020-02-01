using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchGround : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {       
        if(collision.gameObject.tag == "Floor")
        {
            GetComponentInParent<HeroController>().isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            GetComponentInParent<HeroController>().isGrounded = false;
        }
    }     
}
