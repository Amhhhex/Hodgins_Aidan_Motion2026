using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Rigidbody2D rb;

    public float timer;

    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        rb.AddRelativeForce(gameObject.transform.right * speed, ForceMode2D.Force);

        if(timer >= 3f)
        {
            speed *= -1f;
            timer = 0f;
        }

        
    }
}
