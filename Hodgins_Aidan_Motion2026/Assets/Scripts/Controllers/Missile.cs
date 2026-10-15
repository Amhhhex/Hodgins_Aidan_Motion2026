using UnityEngine;

public class Missile : MonoBehaviour
{

    public float speed;

    public float trackingSpeed;

    public float rotation;

    public Vector3 currentVelocity;

    public GameObject player;

    public GameObject enemy;

    public float radius;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentVelocity = player.transform.up;
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        

        currentVelocity += currentVelocity.normalized * speed * Time.deltaTime;


        Homing(radius);


        transform.position = transform.position + currentVelocity * Time.deltaTime;

        

    }

    void Homing(float radius)
    {

        if(Vector3.Distance(enemy.transform.position, transform.position) < radius)
        {
            Vector3 vectorToEnemy = enemy.transform.position - transform.position;

            currentVelocity += vectorToEnemy.normalized * trackingSpeed * Time.deltaTime;

            float angleToEnemy = Mathf.Atan2(vectorToEnemy.y, vectorToEnemy.x) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(0f, 0f, angleToEnemy - 90f);
        }

    }
}
