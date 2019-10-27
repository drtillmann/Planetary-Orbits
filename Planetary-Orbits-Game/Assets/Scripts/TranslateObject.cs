using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObject : MonoBehaviour
{
    public float speed = 2f;
    public float height = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*
        time += Time.deltaTime;
        Debug.Log(time.ToString());
        float newY = (height * (Mathf.Sin(speed * time)));
        Debug.Log("Y Coordinate: " + newY.ToString());
        transform.Translate(new Vector3(0, newY, 0));
        */
        float newY = Mathf.Sin(speed * Time.time) * height;
        if (Mathf.Sign(newY) == -1)
        {
            newY = 0f;
        }
        Vector3 vector = new Vector3(transform.position.x, newY, transform.position.z);
        transform.position = vector;
    }
}
