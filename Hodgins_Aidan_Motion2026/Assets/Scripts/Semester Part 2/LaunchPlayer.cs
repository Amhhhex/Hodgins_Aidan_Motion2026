using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{

    public Rigidbody2D rb;

    public float force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.AddForceAtPosition(gameObject.transform.right * (-1f * force), new Vector2(6, -3.5f), ForceMode2D.Force);
    }


    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    collision.rigidbody.AddForceAtPosition(gameObject.transform.right * -1f, new Vector2(6, -3.5f));
    //}
}
