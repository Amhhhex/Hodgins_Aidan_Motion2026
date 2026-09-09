using UnityEngine;
using UnityEngine.InputSystem;

public class VectorAddition : MonoBehaviour
{

    public Transform rTransform;
    public Transform bTransform;

    public Vector2 origin = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 rPlusB = rTransform.position + bTransform.position;


        if(Keyboard.current.bKey.isPressed)
        {
            Debug.DrawLine(origin, bTransform.position, Color.blue);
        }

        if (Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(origin, rTransform.position, Color.red);
        }

        if(Keyboard.current.bKey.isPressed && Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(origin, rPlusB, Color.magenta);

        }



        float sizeOfRPlysB = Mathf.Sqrt((rPlusB.x * rPlusB.x) + (rPlusB.y * rPlusB.y));
        Debug.Log(sizeOfRPlysB);
        Debug.DrawLine(origin, rPlusB, Color.magenta);
    }
}
