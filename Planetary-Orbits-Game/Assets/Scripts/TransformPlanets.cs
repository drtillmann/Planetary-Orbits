using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformPlanets : MonoBehaviour
{
    public Transform target;
    public float speed;
    GameObject tbxSunSpeed;
    GameObject tbxEarthSpeed;
    GameObject tbxMoonSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = this.gameObject.transform;
        }
        tbxSunSpeed = GameObject.FindGameObjectWithTag("tbxSunSpeed");
        tbxEarthSpeed = GameObject.FindGameObjectWithTag("tbxEarthSpeed");
        tbxMoonSpeed = GameObject.FindGameObjectWithTag("tbxMoonSpeed");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
    
    public void updateSunSpeed()
    {
        string sSpeed = tbxSunSpeed.GetComponent<InputField>().text;
        if (isSpeedInputValid(sSpeed) && isSpeedInputNumeric(sSpeed))
        {
            Debug.Log("Sun Speed: " + sSpeed);
            speed = float.Parse(sSpeed);
        }
        else
        {
            Debug.Log("Sun had an invalid speed.");
        }
    }

    public void updateEarthSpeed()
    {
        string sSpeed = tbxEarthSpeed.GetComponent<InputField>().text;
        if (isSpeedInputValid(sSpeed) && isSpeedInputNumeric(sSpeed))
        {
            Debug.Log("Earth Speed: " + sSpeed);
            speed = float.Parse(sSpeed);
        }
        else
        {
            Debug.Log("Earth had an invalid speed.");
        }
    }

    public void updateMoonSpeed()
    {
        string sSpeed = tbxMoonSpeed.GetComponent<InputField>().text;
        if (isSpeedInputValid(sSpeed) && isSpeedInputNumeric(sSpeed))
        {
            Debug.Log("Moon Speed: " + sSpeed);
            speed = float.Parse(sSpeed);
        }
        else
        {
            Debug.Log("Moon had an invalid speed.");
        }
    }

    bool isSpeedInputValid(string speed)
    {
        return !speed.Equals(null) || !speed.Equals("") || speed.Length != 0 || !speed.Equals(string.Empty);
    }

    bool isSpeedInputNumeric(string speed)
    {
        foreach(char x in speed)
        {
            if (!char.IsNumber(x)) return false;
        }
        return true;
    }
}
