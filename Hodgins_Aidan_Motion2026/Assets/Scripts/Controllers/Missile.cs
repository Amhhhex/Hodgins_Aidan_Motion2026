using UnityEngine;

public class Missile : MonoBehaviour
{

    public float speed;

    public Vector3 currentVelocity;

    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentVelocity = player.transform.up;
    }

    // Update is called once per frame
    void Update()
    {


        currentVelocity += currentVelocity.normalized * speed * Time.deltaTime;



        

        transform.position = transform.position + currentVelocity * Time.deltaTime;

    }
}
