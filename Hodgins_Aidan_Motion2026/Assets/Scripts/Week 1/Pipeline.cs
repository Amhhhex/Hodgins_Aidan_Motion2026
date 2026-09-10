using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public float time;

    public List<Vector2> mouseTransforms = new List<Vector2>();

    public Vector2 mousePosition;

    public float magnitude;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.isPressed)
        {
            time += Time.deltaTime;

            if (time > 0.1f)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

                mouseTransforms.Add(mousePosition);

                time = 0f;
            }

        }

        
        for (int i = mouseTransforms.Count - 1; i >= 0; i--)
        {
            if (i - 1 <= 0)
            {
                break;
            }

            Debug.DrawLine(mouseTransforms[i], mouseTransforms[i - 1], Color.purple);

        }


        
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            for (int i = 0; i < mouseTransforms.Count; i++)
            {
                magnitude += mouseTransforms[i].magnitude;
            }

            Debug.Log("Magnitude: " + magnitude);
        }



        magnitude = 0f;
    }
}
