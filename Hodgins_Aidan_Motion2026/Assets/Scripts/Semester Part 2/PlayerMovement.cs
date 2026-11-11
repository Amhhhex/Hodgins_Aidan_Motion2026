using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if(Keyboard.current.dKey.isPressed)
        {
            rb.AddRelativeForce(gameObject.transform.right * speed, ForceMode2D.Impulse);
        }

        if(Keyboard.current.aKey.isPressed)
        {
            rb.AddRelativeForce(gameObject.transform.right * -1f *  speed, ForceMode2D.Impulse);
        }


    }
}
