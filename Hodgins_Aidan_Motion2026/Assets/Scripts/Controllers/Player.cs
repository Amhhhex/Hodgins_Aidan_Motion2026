using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float speed;

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
            Warp(speed);
        }

    }

    public void Warp(float speed)
    {

        Vector3 currentPosition = transform.position;

        //directionToEnemy calculates the vector from the player to the enemy by subtracting the enemy's position from the players current position
        Vector2 directionToEnemy = enemyTransform.position - currentPosition;

        //Here we normalize the vector so that we can multiply it by the amount we want it to warp, instead of warping directly to the enemy (i.e the speed)
        Vector2 normalizedDirection = directionToEnemy.normalized;

        //Then we multiply the normalized by our speed amount to get it to warp a certain distance
        Vector2 warpPosition = normalizedDirection * speed;

        //Vector2.Lerp(currentPosition, warpPosition, speed);

        //warp the player by setting is transform.position to the warp position
        transform.position = warpPosition;



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
