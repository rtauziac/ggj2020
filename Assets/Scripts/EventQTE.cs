using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQTE : MonoBehaviour
{
    int[] ArrowDirection = new int[4];
    public GameObject[] Arrow;
    float D_Horizontal;
    float D_Vertical;

    bool isPushing;
    int Etape = 0;
    bool QTEStart;

    // Start is called before the first frame update
    void Start()
    {
        isPushing = false;
        QTEStart = true;
        for(int i=0; i<4; i++)
        {
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

    // Update is called once per frame
    void Update()
    {
        D_Horizontal = GetComponentInParent<HeroController>().ArrowQTE.x;
        D_Vertical = GetComponentInParent<HeroController>().ArrowQTE.y;
        
        if(D_Horizontal == 0 && D_Vertical == 0)
        {

            // Droite
            if(D_Horizontal >= 0.9f)
            {
                if(ArrowDirection[Etape] == 4)
                {
                    Etape++;
                    Debug.Log("Yes" + Etape);
                }
                else
                {
                    Etape = 0;
                }
            }
            // Gauche
            else if(D_Horizontal <= -0.9f)
            {
                if(ArrowDirection[Etape] == 3)
                {
                    Etape++;
                    Debug.Log("Yes" + Etape);
                }
                else
                {
                    Etape = 0;
                }
            }
            // Haut
            else if(D_Vertical >= 0.9f)
            {
                if(ArrowDirection[Etape] == 1)
                {
                    Etape++;
                    Debug.Log("Yes" + Etape);
                }
                else
                {
                    Etape = 0;
                }
            }
            // Bas
            else if(D_Vertical <= -0.9f)
            {
                if(ArrowDirection[Etape] == 2)
                {
                    Etape++;
                    Debug.Log("Yes" + Etape);
                }
                else
                {                
                    Etape = 0;
                    Debug.Log(Etape);
                }
            }
        }       
    }
}
