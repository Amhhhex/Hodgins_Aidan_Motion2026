using UnityEngine;
using UnityEngine.InputSystem;

public class ForcesTest : MonoBehaviour
{

    public Rigidbody2D rb;

    public float forceStrength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = 0;

            Vector3 directionToMouse = mousePosition - transform.position;

            rb.AddForce(directionToMouse.normalized * forceStrength);
        }

        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEntered");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("CollisionExit");

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("CollisionStayed");

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exit");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger Stay");
    }


}
