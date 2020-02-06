using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public bool cinematic;
    public Camera plan;
    float zoom;
    float zoomTransition;
    float travelingTransition;
    private bool approcher;
    public GameObject pos1;
    public GameObject pos2;
    Vector2 pos1Vec;
    Vector2 pos2Vec;
    float distanceEntreJoueurs;
    float VitesseZoom;
    // Start is called before the first frame update
    void Start()
    {
        zoomTransition = 1f;
        travelingTransition = -5f;

        zoom = 7f;

    }

    // Update is called once per frame
    void Update()
    {       
        if(cinematic)
        {
            transform.position = new Vector3(-100, 0, -10);
            plan.orthographicSize = 10;
        }
        else
        {
            pos2Vec = pos2.transform.position;
            pos1Vec = pos1.transform.position;

            distanceEntreJoueurs = Vector2.Distance(pos1.transform.position, pos2.transform.position);

            transform.position = new Vector3((pos1Vec.x + pos2Vec.x) / 2, (pos1Vec.y + pos2Vec.y) / 2, -10);
            if(distanceEntreJoueurs > 20 && zoom < 10) 
            {
                zoom += Time.deltaTime * VitesseZoom;
                VitesseZoom += Time.deltaTime * 16;
            }
            else if(distanceEntreJoueurs < 20 && zoom > 7)
            {
                zoom -= Time.deltaTime * VitesseZoom;
                VitesseZoom += Time.deltaTime * 16;
            }
            else if(zoom < 7)
            {
                zoom += Time.deltaTime * VitesseZoom * 30;
                VitesseZoom += Time.deltaTime * 16;
                if(zoom > 7)
                {
                    zoom = 7;
                }                    
            }                
            else
            {
                VitesseZoom = 1;
            }            
            plan.orthographicSize = zoom;  // zoom normal = 7  dézoom max = 15
        }
    }          
}

