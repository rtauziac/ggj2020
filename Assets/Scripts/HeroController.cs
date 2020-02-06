using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour
{
    // Assez proche du robot >2.5f
    AudioSource Son_Zoe;
    public AudioClip[] pas;
    public AudioClip[] voix;
    public AudioClip[] Sonsaut; 
    public AudioClip Sondebris;
    public Text NbDebris;       
    public float jumpForce;
    public bool isGrounded;
    public bool makeAction;
    float action;
    Vector2 direction;
    public Vector2 ArrowQTE;
    public float maxSpeed;
    Animator anim;
    public int debris;
    public Sprite SwitchOn;
    bool facingLeft = false;
    public bool fin;

    void Start()
    {
        anim = GetComponent<Animator>();
        Son_Zoe = GetComponent<AudioSource>();
        foreach(Collider2D collider in GameObject.Find("Robot").GetComponents<Collider2D>())
        {
            foreach(Collider2D colliderZoe in GetComponents<Collider2D>())
            {
                Physics2D.IgnoreCollision(collider, colliderZoe);
            }
        }        
        
    }
    void FixedUpdate()
    {
        anim.SetFloat("hspeed", direction.x);
        anim.SetFloat("vspeed", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("floorcontact", isGrounded);

        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

 	    if (direction.x < 0 && !facingLeft) 
        {
            Flip ();
 		} 
	    else if (direction.x > 0 && facingLeft) 
        {
  		    Flip ();
 		}
	
       // Debug.Log(ArrowQTE);
        // Debug.Log(direction.x);
    }

    void Update()
    {   
        NbDebris.text = "" + debris;
        if(makeAction)
        {
            StartCoroutine(TempsAction());
        }
    }
    
    void OnMove(InputValue value) 
    {
        direction = value.Get<Vector2>(); 
    }
    void OnAction(InputValue value) 
    {
        makeAction = true;
    }
    void OnJump(InputValue value) 
    {
        if(isGrounded)
        {
            anim.SetTrigger("jump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
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
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Switch")
        {
            if(makeAction)
            {
                other.gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOn;
                for(int i=0; i<=18; i++)
                {
                    if(other.gameObject.name == "Switch (" + i + ")")
                    {
                        Debug.Log("Switch" + i);
                        GameObject.Find("ParametreNiveau").GetComponent<LevelSettings>().SwitchActive[i] = true;
                    }
                }
            }
        }
        if(other.gameObject.name == "TriggerQTEFin")
        {
            fin = true;
        }    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Piece")
        {
            debris++;
            Son_Zoe.PlayOneShot(Sondebris);
            Destroy(other.gameObject);
        }
    }
	void Flip(){
 	facingLeft = !facingLeft;
 	Vector3 theScale = transform.localScale;
 	theScale.x *= -1;
 	transform.localScale = theScale;
	} 
    IEnumerator TempsAction()      
    {
        yield return new WaitForSeconds(0.1f);
        makeAction = false;
    } 

    public void foot()
    {
        int n = Random.Range(0, 6);
        Son_Zoe.PlayOneShot(pas[n], 1f);
    }
    public void saut()
    {
        int n = Random.Range(0, 4);
        Son_Zoe.PlayOneShot(voix[n], 1f);
        n = Random.Range(0, 4);
        Son_Zoe.PlayOneShot(Sonsaut[n], 1f);        
    }    
}

