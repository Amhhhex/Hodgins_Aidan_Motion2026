using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    public float time;

    public int i;

    // Update is called once per frame
    void Update()
    {
        
        DrawConstellations(starTransforms);

    }



    void DrawConstellations(List<Transform> starList)
    {

        if(i + 1 >= starList.Count)
        {
            i = 0;
        }

        time += Time.deltaTime;


        Vector2 lineEnd = Vector2.Lerp(starList[i].position, starList[i + 1].position, time/drawingTime);

        Debug.DrawLine(starList[i].position, lineEnd);

        if(time  > drawingTime)
        {
            i++;
            time = 0f;
        }

     }


    }



    

