using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    public float time;

    // Update is called once per frame
    void Update()
    {
        
        DrawConstellations(starTransforms);

    }



    void DrawConstellations(List<Transform> starList)
    {
        //time += Time.deltaTime;

        //for (int i = 0; i < starList.Count;)
        //{

        //    if(i + 1 >= starList.Count)
        //    {
        //        break;
        //    }
        //    ///
        //    ///
        //    /// USE LERP DUMB BITCH ASS
        //    ///

        //    ///
        //    Vector2 startingPoint = starList[i].position;

        //    Vector2 endPoint = starList[i + 1].position;

        //    Vector2 directionToStar = endPoint - startingPoint;

        //    Vector2 magnitudeToStar = directionToStar * (time / drawingTime);

        //    Debug.DrawLine(startingPoint, magnitudeToStar, Color.yellow);

        //Debug.Log("Drawing");
        //}


        }



    }

