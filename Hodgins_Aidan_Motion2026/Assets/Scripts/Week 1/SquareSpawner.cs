using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{

    public float size;
    public GameObject square;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        
        size += Input.mouseScrollDelta.y;
        

        if (square == null )
        {
            square = GameObject.CreatePrimitive(PrimitiveType.Cube);
            square.transform.localScale = new Vector3(size * 2, size * 2, size * 2);    
            square.GetComponent<Renderer>().material.color = new Color(0.75f, 0.75f, 0.0f, 0.9f);
        }

        square.transform.position = currentMousePosition;
        

        


        if (Mouse.current.leftButton.isPressed)
        {
            

            Vector2 topLeftCorner = new Vector2(currentMousePosition.x - size, currentMousePosition.y + size);
            Vector2 topRightCorner = new Vector2(currentMousePosition.x + size, currentMousePosition.y + size);
            Vector2 bottomLeftCorner = new Vector2(currentMousePosition.x - size, currentMousePosition.y - size);
            Vector2 bottomRightCorner = new Vector2(currentMousePosition.x + size, currentMousePosition.y - size);

            Debug.DrawLine(topLeftCorner, topRightCorner, Color.red, 10f);
            Debug.DrawLine(topRightCorner, bottomRightCorner, Color.red, 10f);
            Debug.DrawLine(bottomRightCorner, bottomLeftCorner, Color.red, 10f);
            Debug.DrawLine(bottomLeftCorner, topLeftCorner, Color.red, 10f);

            Debug.Log(topLeftCorner);
        }
        
        
    }
}
