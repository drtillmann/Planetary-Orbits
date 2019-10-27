using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    //public GameObject objectPrefab;
    GameObject tbxNumBalls;
    GameObject tbxDelay;
    InputField ballInput;
    InputField delayInput;
    public static int numBalls = 100;
    public float delay = 0.1f;
    float timer = 0.0f;
    float interval = 0.5f;
    int counter = 0;

    float fBallInput;

    // Start is called before the first frame update
    void Start()
    {
        tbxNumBalls = GameObject.FindGameObjectWithTag("tbxNumBalls");
        if (tbxNumBalls != null)
        {
            Debug.Log(tbxNumBalls.tag);
            ballInput = tbxNumBalls.GetComponent<InputField>();
        }
        tbxDelay = GameObject.FindGameObjectWithTag("tbxDelay");
        if (tbxDelay != null)
        {
            Debug.Log(tbxDelay.tag);
            delayInput = tbxDelay.GetComponent<InputField>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counter < numBalls)
        {
            timer += Time.deltaTime;
            if (timer > (interval + delay))
            {
                counter++;
                Debug.Log(counter.ToString());
                timer = 0;
                Spawn();
            }
        }
    }

    internal void Spawn()
    {
        Vector3 spawnLoc = gameObject.transform.position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
        GameObject ball = ObjectPooler.instance.getPooledObject();
        if (ball != null)
        {
            ball.SetActive(true);
        }
        //GameObject.Instantiate(objectPrefab, spawnLoc, Quaternion.identity);
        GameObject.Instantiate(ball, spawnLoc, Quaternion.identity);
    }

    public void updateNumberOfBalls()
    {
        string newNumBalls = ballInput.text.Trim();
        if (isInputValid(newNumBalls) && isInputNumeric(newNumBalls))
        {
            numBalls = int.Parse(newNumBalls);
            ObjectPooler.instance.updateBallCount(numBalls);
            counter = 0;
            Debug.Log("Number of balls updated: " + newNumBalls);
        }
        else
        {
            Debug.Log("Invalid Input: number of balls");
        }
    }

    public void updateDelay()
    {
        string newDelay = delayInput.text.Trim();
        if (isInputValid(newDelay) && isInputNumeric(newDelay))
        {
            delay = float.Parse(newDelay);
            Debug.Log("Delay updated: " + newDelay);
        }
    }

    public static int getNumberOfBalls()
    {
        return numBalls;
    }

    bool isInputValid(string count)
    {
        return !count.Equals(null) || !count.Equals("") || count.Length != 0 || !count.Equals(string.Empty);
    }

    bool isInputNumeric(string count)
    {
        foreach (char x in count)
        {
            if (!char.IsNumber(x)) return false;
        }
        return true;
    }
}
