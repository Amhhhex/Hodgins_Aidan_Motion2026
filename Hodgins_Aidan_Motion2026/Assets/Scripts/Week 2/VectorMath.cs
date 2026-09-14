using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        DrawSquare(currentMousePosition, 5f, Color.red, 0.5f);
        
    }


    public static float GetMagnitude(Vector2 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

    public static Vector2 GetNormalizedVector(Vector2 vector)
    {
        float sizeOfVector = GetMagnitude(vector);

        //Gives us a vector that has a size of 1 but keeps the same direction from before
        Vector2 normalizedVector = new Vector2(vector.x / sizeOfVector, vector.y / sizeOfVector);

        return normalizedVector;
    }

    public static void DrawSquare(Vector2 centerPoint, float size, Color colour, float duration)
    {
        //Center point & the size

        //Color

        //Duration how long to show

        //TOP LINE:
        Vector2 startPoint = centerPoint + new Vector2(-size, size);
        Vector2 endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //LEFT LINE:
        startPoint = centerPoint + new Vector2(-size, size);
        endPoint = centerPoint + new Vector2(-size, -size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //BOTTOM LINE:
        startPoint = centerPoint + new Vector2(-size, -size);
        endPoint = centerPoint + new Vector2(size, -size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //RIGHT LINE:
        startPoint = centerPoint + new Vector2(size, -size);
        endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);



        /*
         * 
         * Static Methods
         *  Static methods are methods that are accessible without a reference to that specfic script that contains that method, an exmaple is Mathf.sqrt()
         *  
         * Instance Methods
         *  Instance Methods are methods that are contained within that objects specific reference, and require a reference to to execute that method
         *  
         * Static Variables
         *  Same as a static method but apply its functionality to a variable
         *  
         * Instance Variables
         *  Same as a Instance Method, but applies to variables
         *  
         * The diff between transform.up and Vector2.up
         *  transform.up is a vector that points up on a game object in relation to that objects rotation in space, while Vector2.up is a universal vector that always points up Vector2(0, 1)
        


        */
    }
}
