using UnityEngine;

public class FreezeGroundWeek10 : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Static;

        // Update is called once per frame
        void Update()
        {

        }
    }
}
