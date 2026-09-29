using UnityEngine;

public class Orbiting : MonoBehaviour
{

    public Transform planet;
    public GameObject moon;

    public float radius;

    public float time;

    public float speed;

    public int sequence;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        OrbitalMotion(radius, speed, planet);
        
    }


    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        time += Time.deltaTime;

        if (time >= speed)
        {
            sequence++;
            time = 0f;
        }

        if (sequence >= 360)
        {
            sequence = 0;
        }


        Vector3 moonPosition = new Vector3(Mathf.Cos(sequence * Mathf.Deg2Rad), Mathf.Sin(sequence * Mathf.Deg2Rad)) * radius + target.transform.position;


        moon.transform.position = moonPosition;
        

    }

}
