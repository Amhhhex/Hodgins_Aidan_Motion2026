using System.CodeDom.Compiler;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{
    public float size;

    public float spacing;
    
    public TMP_InputField inputField;

    public int xValue;
    public int yValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        string inputText = inputField.text;

        bool success = int.TryParse(inputText, out int value);

        if (success)
        {
            int num = int.Parse(inputText);

            for(int i = 0; i < num; i++)
            {
                Vector2 topLeftCorner = new Vector2((i + spacing * i) - size , yValue + size);
                Vector2 topRightCorner = new Vector2((i + spacing * i) + size, yValue + size);
                Vector2 bottomLeftCorner = new Vector2((i + spacing * i) - size, yValue - size);
                Vector2 bottomRightCorner = new Vector2((i + spacing * i) + size , yValue - size);

                Debug.DrawLine(topLeftCorner, topRightCorner, Color.red, 10f);
                Debug.DrawLine(topRightCorner, bottomRightCorner, Color.red, 10f);
                Debug.DrawLine(bottomRightCorner, bottomLeftCorner, Color.red, 10f);
                Debug.DrawLine(bottomLeftCorner, topLeftCorner, Color.red, 10f);

                Debug.Log(i);

            }
        }

        Debug.Log("Ive been clicked");


    }
}
