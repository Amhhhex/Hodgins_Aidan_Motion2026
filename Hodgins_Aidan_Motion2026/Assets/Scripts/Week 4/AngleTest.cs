using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngleTest : MonoBehaviour
{

    public List<float> listOfAngles = new List<float>();

    public float radius;

    public Vector2 origin;

    public int j = 0;

    public float time;

    public float timeLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        float fortyFiveDegree = 45f;

        float ffDInRadians = fortyFiveDegree * Mathf.Deg2Rad;

        float twoPiRadians = 2 * Mathf.PI;

        float tprInDegrees = twoPiRadians * Mathf.Rad2Deg;

        float currentAngle = 90f;

        for(int i = 0; i < 10f; i++)
        {
            listOfAngles.Add(3 +(20 * i));
        }



        Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if(j >= listOfAngles.Count)
        {
            j = 0;
        }

        
        Debug.DrawLine(origin, new Vector2(Mathf.Cos(listOfAngles[j] * Mathf.Deg2Rad), Mathf.Sin(listOfAngles[j] * Mathf.Deg2Rad)) * radius + origin, Color.red);
        

        if(time >= timeLimit)
        {
            j++;
            time = 0f;
        }

        //Degrees is a unit of measurement that is easy for people to understand, and one that we are familiar with. While radians are a more abstract measurement of rotation
        //but are more accurate for measurements. So when doing angles in unity you can use the degrees you want, and convert it to radians using Mathf.Deg2Rad and vice versa
        //to convert the value from one to another


        //Angle of a vector is the degrees from the X that vector is away from. For example if the angle of the vector is 90 degrees, that means it is shooting directly up


        //A unit circle is a circle starting at (0, 0) with a radius of one. This is useful because the hypotneuses length is always 1 (i.e normalized). So if we want to find the
        //position on a circle, we can use the unit circle to use the equation P = ((sin(theta), cos(theta)) * radius) to get that position on the circle

        
        /*
         * The problem with determining a direction for rotation is that under certain condiditons you can get the same answers, such as an angle of 45 and -45
         * This gives us a problem if we want to determine an angle from just a vector
         * 
         * For sin, cos and tan you input an angle, and it will spit our the direction. To get the opposite we need to use aSin, aCos, aTan to find it out
         * 
         * Mathf.Atan will give us the problem from before, where negative angles/opposite angles will give us the same answer, due to the quadrants (x, y) and (-x, -y)
         * Mathf.Atan2 solves this issue by accounting for the sign (+/-) of the inputs to give us our desired result
         * 
         * 
         * 
         */


    }
}
