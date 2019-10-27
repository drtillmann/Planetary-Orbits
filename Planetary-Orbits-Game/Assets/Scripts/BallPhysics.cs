using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{

    public GameObject ball;
    float force = 1000;
    Rigidbody rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot();
        }
    }

    void shoot()
    {
        Debug.Log("Called shoot");
        rigid.AddForce(Vector3.forward * force);
    }
}
