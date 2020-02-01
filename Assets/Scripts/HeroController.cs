using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded = false;
    Vector2 direction;
    public Vector2 ArrowQTE;
    public float maxSpeed;

    void Start()
    {

    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        Debug.Log(ArrowQTE);
        // Debug.Log(direction.x);
    }
    
    void OnMove(InputValue value) 
    {
        direction = value.Get<Vector2>(); 
    }

    void OnJump(InputValue value) 
    {
        if(isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }
    void OnPause(InputValue value) 
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            GameObject.Find("Canvas/BlackScreen").GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            Time.timeScale = 0;
            GameObject.Find("Canvas/BlackScreen").GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
        }        
    }
    void OnQTE(InputValue value) 
    {
        ArrowQTE = value.Get<Vector2>(); 
        
        
    }       
}
