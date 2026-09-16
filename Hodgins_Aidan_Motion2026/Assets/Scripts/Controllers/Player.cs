using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float speed;

    public float bombSpacing;
    public int numberOfBombs;

    public float cornerSpacing;

    //Is used to safely stop and start the coroutine
    public Coroutine currentCoroutine;


    void Update()
    {
        //Checking to see if the b key was pressed
        if(Keyboard.current.bKey.wasPressedThisFrame)
        {
            //checking the current coroutine to see if it is empty or not
            if(currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }

            //starting the coroutine
            StartCoroutine(SpawnBombAtOffset(Vector2.up));
        }

        if(Keyboard.current.wKey.wasPressedThisFrame)
        {
            WarpUpdated(speed);
        }

        if(Keyboard.current.tKey.wasPressedThisFrame)
        {
            BombTrail(numberOfBombs, bombSpacing);
        }

        if(Keyboard.current.cKey.wasPressedThisFrame)
        {
            CornerBombs(cornerSpacing);
        }

        DetectAsteroids(2.5f, asteroidTransforms);

    }

    public void Warp(float speed)
    {

        //speed = Mathf.Clamp01(speed);

        Vector3 currentPosition = transform.position;
        

        Debug.Log(enemyTransform.position);



        //directionToEnemy calculates the vector from the player to the enemy by subtracting the enemy's position from the players current position
        Vector3 directionToEnemy = enemyTransform.position - currentPosition;

        

        //Here we normalize the vector so that we can multiply it by the amount we want it to warp, instead of warping directly to the enemy (i.e the speed)
        Vector2 normalizedDirection = directionToEnemy.normalized;

        Debug.DrawLine(currentPosition, directionToEnemy, UnityEngine.Color.red, 45f);

        //Then we multiply the normalized by our speed amount to get it to warp a certain distance
        Vector3 warpPosition = normalizedDirection * speed;

        //Vector2.Lerp(currentPosition, warpPosition, speed);

        //To have the player move in the intended direction we takes the players current position, add what the warped position would be, creating the new warp position
        //And then we set the players transform to equal this position
        transform.position = currentPosition + warpPosition;



    }

    public void WarpUpdated(float speed)
    {
        speed = Mathf.Clamp01(speed);
        Vector2 currentPosition = transform.position;

        Vector2 LerpPosition = Vector2.Lerp(currentPosition, enemyTransform.position, speed);

        transform.position = LerpPosition;
    }

    public void BombTrail(int bombNum, float bombSpacing)
    {
        Vector2 currentPosition = transform.position;
        currentPosition.y -= bombSpacing;

        

        for(int i = 0; i < bombNum; i++)
        {
            Instantiate(bombPrefab, currentPosition + new Vector2(currentPosition.x, -bombSpacing * i), Quaternion.identity);
        }

    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        Vector3 currentPosition = transform.position;

        float distanceToAsteroid;

        for(int i = 0;i < inAsteroids.Count;i++)
        {
            distanceToAsteroid = Vector2.Distance(currentPosition, inAsteroids[i].position);

            if(distanceToAsteroid <= inMaxRange)
            {
                Vector3 directionToAsteroid = inAsteroids[i].position - currentPosition;

                Vector3 normalizedDirectionToAsteroid = directionToAsteroid.normalized;

                Vector3 magnitudeDirectionToAsteroid = normalizedDirectionToAsteroid * 2.5f;

                Debug.DrawLine(currentPosition, currentPosition + magnitudeDirectionToAsteroid, UnityEngine.Color.green);
            }
        }
    }

    public void CornerBombs(float inDistance)
    {
        Vector2 currentPosition = transform.position;

        Vector2 topLeftCorner = new Vector2(currentPosition.x - inDistance, currentPosition.y + inDistance);
        Vector2 topRightCorner = new Vector2(currentPosition.x + inDistance, currentPosition.y + inDistance);
        Vector2 bottomLeftCorner = new Vector2(currentPosition.x - inDistance, currentPosition.y - inDistance);
        Vector2 bottomRightCorner = new Vector2(currentPosition.x + inDistance, currentPosition.y - inDistance);

        List<Vector2> corners = new List<Vector2>();

        corners.Add(topLeftCorner);
        corners.Add(topRightCorner);
        corners.Add(bottomLeftCorner);
        corners.Add(bottomRightCorner);

        int randomNumber = Random.Range(0, 4);

        Instantiate(bombPrefab, corners[randomNumber], Quaternion.identity);


    }


    IEnumerator SpawnBombAtOffset(Vector2 inOffset)
    {

        //when it is called will wait 3 seconds before continuing the coroutine
        yield return new WaitForSeconds(3f);
        
        //grab the current transform of the player controller
        Vector2 currentPosition = transform.position;


        //spawn the bomb at the players current position by an offset
        Instantiate(bombPrefab, currentPosition + inOffset, Quaternion.identity);


        //yield control back to unity
        yield return null;
    }

    
}
