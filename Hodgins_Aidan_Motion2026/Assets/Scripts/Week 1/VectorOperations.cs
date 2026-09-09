using UnityEngine;

public class VectorOperations : MonoBehaviour
{

    public Vector2 redVector;
    public Vector2 blueVector;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 redPlusBlue = redVector + blueVector;
        //R + B x: 1 + 2 = 3
        //R + B y: 3 + 2 = 5
        //R + B: 3, 5

        Vector2 redMinusBlue = redVector - blueVector;


        Vector2 origin = Vector2.zero;

        Debug.DrawLine(origin, redPlusBlue, Color.purple);
        Debug.DrawLine(origin, redMinusBlue, Color.pink);

        Debug.DrawLine(origin, redVector, Color.red);
        Debug.DrawLine(origin, blueVector, Color.blue);


    }
}
