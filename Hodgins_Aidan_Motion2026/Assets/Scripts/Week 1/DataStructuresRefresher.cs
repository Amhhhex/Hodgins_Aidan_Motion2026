using UnityEngine;

public class DataStructuresRefresher : MonoBehaviour
{

    Vector2 dVector = new Vector2(0, 1);
    Vector2 eVector = new Vector2(3, 2);

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Vector2 originPosition = new Vector2(0, 0);

        Vector2 currentPosition = new Vector2(3, -2);

        Debug.DrawLine(originPosition, eVector, Color.gray, 15f);

        Debug.DrawLine(originPosition, dVector, Color.yellow, 15f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
