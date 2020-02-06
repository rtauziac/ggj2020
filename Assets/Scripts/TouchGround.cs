using UnityEngine;
public class TouchGround : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {       
        if(collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Door")
        {
            if(gameObject.transform.parent.name == "Zoe")
            {            
                GetComponentInParent<HeroController>().isGrounded = true;
            }
            else if(gameObject.transform.parent.name == "Robot")
            {
                GetComponentInParent<RobotController>().isGrounded = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Door")
        {
            if(gameObject.transform.parent.name == "Zoe")
            {
                Debug.Log("gnee..");
                GetComponentInParent<HeroController>().isGrounded = false;
            }
            else if(gameObject.transform.parent.name == "Robot")
            {
                GetComponentInParent<RobotController>().isGrounded = false;
            }
        }
    }     
}
