using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBall : MonoBehaviour
{

    ObjectSpawner objectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (gameObject.tag.Equals("Ball"))
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
