using UnityEngine;
using UnityEngine.InputSystem;

public class CannonExercise : MonoBehaviour
{

    public GameObject cannonBall;

    public GameObject leftCannon;
    public GameObject rightCannon;

    public float force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject leftCannonBall = Instantiate(cannonBall, leftCannon.transform.position, Quaternion.identity);

            Rigidbody2D cannonBallrb = leftCannonBall.GetComponent<Rigidbody2D>();

            
            cannonBallrb.AddForce(leftCannon.transform.right * force, ForceMode2D.Impulse);
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            GameObject leftCannonBall = Instantiate(cannonBall, rightCannon.transform.position, Quaternion.identity);

            Rigidbody2D cannonBallrb = leftCannonBall.GetComponent<Rigidbody2D>();

            cannonBallrb.AddForce(rightCannon.transform.right * force, ForceMode2D.Impulse);
        }

    }
}
