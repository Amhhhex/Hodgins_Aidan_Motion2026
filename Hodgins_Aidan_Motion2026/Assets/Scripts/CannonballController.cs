using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CannonballController : MonoBehaviour
{
    public float lifespan;



    // Start is called before the first frame update
    void Start()
    {
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This checks to see if the collider THIS object is running into has the CannonballController script
        //IF it does have it, then we destroy THIS object
        if(collision.collider.gameObject.GetComponent<CannonballController>() != null)
        {
            Debug.Log("Hit!!");
            Destroy(gameObject);
        }

        if(collision.collider.gameObject.name == "Pirate Ship Target")
        {
            Destroy(gameObject);
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
