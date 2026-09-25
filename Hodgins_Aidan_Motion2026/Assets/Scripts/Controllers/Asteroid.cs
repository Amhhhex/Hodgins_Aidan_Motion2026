using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {

        Vector3 randomVector3 = Random.insideUnitSphere;

        randomVector3.z = 0f;

        randomPosition = transform.position + (randomVector3 * maxFloatDistance);

    }

    // Update is called once per frame
    void Update()
    {

        AsteriodMovement();



    }


    public void AsteriodMovement()
    {
        


        Vector3 directionToPosition = randomPosition - transform.position;

        Vector3 normalizeToPosition = directionToPosition.normalized;

        Vector3 magnitudeToPosition = normalizeToPosition * moveSpeed;

        Debug.DrawLine(directionToPosition, transform.position, Color.green);

        transform.position += magnitudeToPosition * Time.deltaTime;

        float distanceToPosition = Vector3.Distance(transform.position, randomPosition);

        Debug.Log("Distance to Position: " +  distanceToPosition);

        if(distanceToPosition < arrivalDistance)
        {

            Vector3 randomVector3 = Random.insideUnitSphere;

            randomVector3.z = 0f;

            randomPosition = transform.position + (randomVector3 * maxFloatDistance);

        }

    }
}
