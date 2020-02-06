using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class RobotController : MonoBehaviour
{
    AudioSource Son_Robot;
    public AudioClip[] pas;
    public AudioClip[] voix;
    public AudioClip[] Sonsaut;

    public float jumpForce;
    public Text etatRobot;
    public bool isGrounded = false;
    public bool makeAction;
    public Sprite SwitchOn;
    float action;
    public int etat = 3;
    bool facingLeft = false;
    Animator anim;
    Vector2 direction;
    public Vector2 ArrowQTE;
    public float maxSpeed;
    public bool fin;
    void Start()
    {
        anim = GetComponent<Animator>();
        Son_Robot = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        anim.SetFloat("hspeed", direction.x);
        anim.SetFloat("vspeed", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("floorcontact", isGrounded);
 	    
         if (direction.x < 0 && !facingLeft) 
        {
            Flip ();
 		} 
	    else if (direction.x > 0 && facingLeft) 
        {
  		    Flip ();
 		}

        if(etat >= 3)
        {
            etatRobot.text = "Etat robot : Normal";
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(etat == 2)
        {
            etatRobot.text = "Etat robot : Endommagé";
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * (maxSpeed/2), GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(etat == 1)
        {
            etatRobot.text = "Etat robot : Critique";
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * (maxSpeed/4), GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            etatRobot.text = "Etat robot : Hors service";
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * maxSpeed * 0, GetComponent<Rigidbody2D>().velocity.y);
        }          
        if(Input.GetKeyDown(KeyCode.B))
        {
            etat--;
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            etat++;
        }        

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
        if(etat >= 2)
        {
            makeAction = true;
        }        
        
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
                etat--;
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
	void Flip(){
 	facingLeft = !facingLeft;
 	Vector3 theScale = transform.localScale;
 	theScale.x *= -1;
 	transform.localScale = theScale;
	} 

    IEnumerator TempsAction()      
    {
        yield return null;
        makeAction = false;
    }

    public void WalkRobot()      
    {
        int n = Random.Range(0, 5);
        Son_Robot.PlayOneShot(pas[n], 1f);
    }

    public void sautRobot()      
    {
        int n = Random.Range(0, 7);
        Son_Robot.PlayOneShot(voix[n], 1f);
    }
    public void atteriRobot()      
    {
        int n = Random.Range(0, 4);
        Son_Robot.PlayOneShot(Sonsaut[n], 1f);
    }     
}

