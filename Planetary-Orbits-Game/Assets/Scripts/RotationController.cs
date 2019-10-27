using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationController : MonoBehaviour
{
    ArrayList comps = new ArrayList();
    ArrayList initSpeeds = new ArrayList();
    float zeroSpeed = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        saveComponentsAndInitSpeeds();
               
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("StartRotate"))
        {
            Debug.Log("y clicked");
            startRotation();
        }else if (Input.GetButtonDown("StopRotate"))
        {
            Debug.Log("n clicked");
            stopRotation();
        }
    }

    public void btnStart()
    {
        Debug.Log("Start Button Clicked.");
        startRotation();
    }

    public void btnStop()
    {
        Debug.Log("Stop Button Clicked.");
        stopRotation();
    }

    private void startRotation()
    {
        //start the rotation of all game objects using their original speeds
        int index = 0;
        foreach (TransformPlanets tp in comps)
        {
            tp.speed = (float)initSpeeds[index];
            index++;
        }
    }

    private void stopRotation()
    {
        //stop rotation of all game objects
        foreach (TransformPlanets tp in comps)
        {
            tp.speed = zeroSpeed;
        }
    }

    private void saveComponentsAndInitSpeeds()
    {
        foreach (Component comp in gameObject.GetComponents(typeof(Component)))
        {
            if (comp.GetType() == typeof(TransformPlanets))
            {
                TransformPlanets tp = comp as TransformPlanets;
                saveComponents(tp);
                saveSpeeds(tp.speed);
            }
        }
    }

    private void saveSpeeds(float speed)
    {
        initSpeeds.Add(speed);
    }

    private void saveComponents(TransformPlanets transformPlanets)
    {
        comps.Add(transformPlanets);
    }

    /*
    private void startStopRotation(bool rotate)
    {
        if (!rotate)
        {
            //stop rotation of all game objects
            foreach (TransformPlanets tp in comps)
            {
                tp.speed = zeroSpeed;
            }
        }
        else
        {
            //start the rotation of all game objects using their original speeds
            int index = 0;
            foreach (TransformPlanets tp in comps)
            {
                tp.speed = (float)initSpeeds[index];
                index++;
            }
        }
    }
    */
}


