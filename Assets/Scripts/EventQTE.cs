using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQTE : MonoBehaviour
{
    // X-2.5 // X-11
    AudioSource QteSon;
    public AudioClip[] QteEventSon;
    int[] ArrowDirection = new int[4];
    public GameObject[] Arrow;
    float D_Horizontal;
    float D_Vertical;
    public GameObject Zoe;
    public GameObject Robot;
    float distanceRobotZoe;
    public bool isPushing;
    int Etape;
    public bool QTEStart;

    // Start is called before the first frame update
    void Start()
    {
        Arrow[0].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f);
        Arrow[1].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f);
        Arrow[2].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f); 
        Arrow[3].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f);  
        QteSon = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceRobotZoe = Vector2.Distance(Zoe.transform.position, Robot.transform.position);

        if(distanceRobotZoe < 2.5 && !QTEStart && Zoe.GetComponent<HeroController>().makeAction && Zoe.GetComponent<HeroController>().debris > 0)
        {
            Arrow[0].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.9635534f, 1f);
            Arrow[1].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.9635534f, 1f);
            Arrow[2].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.9635534f, 1f); 
            Arrow[3].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.9635534f, 1f);   
            QteSon.PlayOneShot(QteEventSon[2], 1f);
            transform.position = new Vector3(Zoe.transform.position.x, Zoe.transform.position.y + 3, Zoe.transform.position.y + 40);
            isPushing = false;
            QTEStart = true;
            for(int i=0; i<4; i++)
            {
                Etape = 0; 
                ArrowDirection[i] = Random.Range(1, 5);  // 1 = Haut // 2 = Bas // 3 = Gauche // 4 = Droite
                switch(ArrowDirection[i])
                {
                    case 1 :
                    Arrow[i].transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                    case 2 :
                    Arrow[i].transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                    case 3 :
                    Arrow[i].transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                    case 4 :
                    Arrow[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;                                
                }
                    
            }
            Debug.Log(ArrowDirection[0] + " / " + ArrowDirection[1] + " / " + ArrowDirection[2] + " / " + ArrowDirection[3]);
        }
        else if(distanceRobotZoe < 2.5 && !QTEStart && Zoe.GetComponent<HeroController>().makeAction && Zoe.GetComponent<HeroController>().debris < 0)
        {
            // Il me faut des débris... 
            QteSon.PlayOneShot(QteEventSon[1], 1f);
        }
        D_Horizontal = Zoe.GetComponent<HeroController>().ArrowQTE.x;
        D_Vertical = Zoe.GetComponent<HeroController>().ArrowQTE.y;
        
        if(QTEStart && !isPushing && (D_Horizontal != 0 || D_Vertical != 0))
        {
            isPushing = true;
            // Droite
            if(D_Horizontal >= 0.7f)
            {
                if(ArrowDirection[Etape] == 4)
                {
                    Etape++;
                    Debug.Log("Yes" + Etape);
                }
                else
                {
                    QteSon.PlayOneShot(QteEventSon[1], 1f);
                    Etape = 0;                 
                }
            }
            // Gauche
            else if(D_Horizontal <= -0.7f)
            {
                if(ArrowDirection[Etape] == 3)
                {
                    Etape++;
                    Debug.Log("Yes" + Etape);
                }
                else
                {
                    QteSon.PlayOneShot(QteEventSon[1], 1f);
                    Etape = 0;
 
                }
            }
            // Haut
            else if(D_Vertical >= 0.7f)
            {
                if(ArrowDirection[Etape] == 1)
                {
                    Etape++;
                    Debug.Log("Yes" + Etape);
                }
                else
                {
                    QteSon.PlayOneShot(QteEventSon[1], 1f);
                    Etape = 0;
                }
            }
            // Bas
            else if(D_Vertical <= -0.7f)
            {
                if(ArrowDirection[Etape] == 2)
                {
                    Etape++;
                    Debug.Log("Yes" + Etape);
                }
                else
                {                
                    QteSon.PlayOneShot(QteEventSon[1], 1f);
                    Etape = 0;
                }
            }



            if(Etape == 1)
            {
                Arrow[0].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            }
            else if(Etape == 2)
            {
                Arrow[1].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            }
            else if(Etape == 3)
            {
                Arrow[2].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            }
            else if(Etape >= 4)
            {
                QteSon.PlayOneShot(QteEventSon[0], 1f);
                Arrow[3].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
                Zoe.GetComponent<HeroController>().debris--;
                Robot.GetComponent<RobotController>().etat = 3;
                QTEStart = false;
                Arrow[0].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f);
                Arrow[1].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f);
                Arrow[2].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f); 
                Arrow[3].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0f);                                    
            }                       
            else
            {
                Arrow[0].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.9635534f, 1f);
                Arrow[1].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.9635534f, 1f);
                Arrow[2].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.9635534f, 1f); 
                Arrow[3].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.9635534f, 1f);                                   
            }  
        }
                
        if((D_Horizontal == 0 && D_Vertical == 0) && isPushing)
        {
            isPushing = false;
        }


 

              

    }
}
