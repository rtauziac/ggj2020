using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public GameObject Zoe;
    public GameObject Robot;
    public Sprite DoorUnlock;
    public Animator cinematics;
    public bool[] SwitchActive = new bool [19];
    bool[] door = new bool [12];
    public AudioClip[] Music;
    AudioSource MusicJoue;
    bool victory = false;
    public bool triggerCinematic = false;
    // Start is called before the first frame update
    void Start()
    {
        
        MusicJoue = GetComponent<AudioSource>();
       // StartCoroutine(TempsIntro());        
    }

    // Update is called once per frame
    void Update()
    {
        if(Zoe.GetComponent<HeroController>().fin && !victory)
        {
            victory = true;
            StartCoroutine(Fin());
        }
        if(!GameObject.Find("Main Camera").GetComponent<FollowCamera>().cinematic && GameObject.Find("QTE").GetComponent<EventQTE>().QTEStart == true && MusicJoue.clip != Music[2])
        {
            MusicJoue.clip = Music[2];
            MusicJoue.Play();
        }
        else if(!GameObject.Find("Main Camera").GetComponent<FollowCamera>().cinematic && GameObject.Find("QTE").GetComponent<EventQTE>().QTEStart == false && MusicJoue.clip != Music[1])
        {
            MusicJoue.clip = Music[1];
            MusicJoue.Play();
        }

////////////////////////////////////// LES PORTES //////////////////////////////////////////////////////////////

        if(SwitchActive[5] && SwitchActive[6])
        {
            door[10] = true;
            GameObject.Find("Door/Door (10)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (10)").GetComponent<Collider2D>().enabled = false;
        }

        if(SwitchActive[4])
        {
            door[2] = true;
            door[3] = true;
            GameObject.Find("Door/Door (2)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (2)").GetComponent<Collider2D>().enabled = false;
            GameObject.Find("Door/Door (3)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (3)").GetComponent<Collider2D>().enabled = false;            
        }
        if(SwitchActive[3])
        {
            door[1] = true;
            GameObject.Find("Door/Door (1)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (1)").GetComponent<Collider2D>().enabled = false;       
        }
        if(SwitchActive[1] && SwitchActive[2])
        {
            door[11] = true;
            GameObject.Find("Door/Door (11)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (11)").GetComponent<Collider2D>().enabled = false;       
        }
        if(SwitchActive[17])
        {
            door[4] = true;
            door[5] = true;
            GameObject.Find("Door/Door (4)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (4)").GetComponent<Collider2D>().enabled = false;
            GameObject.Find("Door/Door (5)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (5)").GetComponent<Collider2D>().enabled = false;            
        }                                  
        if(SwitchActive[18])
        {
            door[8] = true;
            GameObject.Find("Door/Door (8)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (8)").GetComponent<Collider2D>().enabled = false;            
        }
        if(SwitchActive[17])
        {
            door[4] = true;
            door[5] = true;
            GameObject.Find("Door/Door (4)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (4)").GetComponent<Collider2D>().enabled = false;
            GameObject.Find("Door/Door (5)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (5)").GetComponent<Collider2D>().enabled = false;                         
        }

        if(SwitchActive[7] && SwitchActive[9])
        {
            door[6] = true;
            GameObject.Find("Door/Door (6)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (6)").GetComponent<Collider2D>().enabled = false;                         
        }
        if(SwitchActive[11] && SwitchActive[13])
        {
            door[7] = true;
            GameObject.Find("Door/Door (7)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (7)").GetComponent<Collider2D>().enabled = false;                         
        } 
        if(SwitchActive[15] && SwitchActive[16])
        {
            door[9] = true;
            GameObject.Find("Door/Door (9)").GetComponent<SpriteRenderer>().sprite = DoorUnlock;
            GameObject.Find("Door/Door (9)").GetComponent<Collider2D>().enabled = false;                         
        }                                     
    }

    IEnumerator TempsIntro()
    {
        MusicJoue.clip = Music[0];
        MusicJoue.Play();
        GameObject.Find("Main Camera").GetComponent<FollowCamera>().cinematic = true;
        cinematics.SetTrigger("intro");
        yield return new WaitForSeconds(10);
        GameObject.Find("Main Camera").GetComponent<FollowCamera>().cinematic = false;
        MusicJoue.clip = Music[1];
        MusicJoue.Play();

    }

    IEnumerator Fin()
    {
        MusicJoue.clip = Music[4];
        MusicJoue.Play();
        GameObject.Find("Main Camera").GetComponent<FollowCamera>().cinematic = true;
        yield return new WaitForSeconds(1);
        cinematics.SetTrigger("outro");
        yield return new WaitForSeconds(13);
        GameObject.Find("Main Camera").GetComponent<FollowCamera>().cinematic = false;
    }    
}
