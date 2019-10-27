using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPooler : MonoBehaviour
{
    int ballRange = ObjectSpawner.getNumberOfBalls(); //[0, getNumberOfBalls()]
    public GameObject objectToPool;
    public List<GameObject> pooledObjects;
    public static ObjectPooler instance;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        Debug.Log("Num Balls to add to pooler: " + ballRange.ToString());
        addNumberOfObjectsToList(ballRange);
        Debug.Log("Pooled the balls.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        instance = this;
    }

    public GameObject getPooledObject()
    {
        /*
        for(int i = 0; i < ballRange; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }*/
        foreach (GameObject ball in pooledObjects)
        {
            if (!ball.activeInHierarchy)
            {
                return ball;
            }
        }
        return null;
    }

    public void updateBallCount(int newCount)
    {
        if (newCount > pooledObjects.Count)
        {
            addBallsToPool(newCount);
        }
        else
        {
            decreaseBallCount(newCount);
        }
    }

    void addBallsToPool(int addition)
    {
        int ballsToAdd = addition - pooledObjects.Count;
        addNumberOfObjectsToList(ballsToAdd);
        Debug.Log("Added balls: " + ballsToAdd.ToString());
    }

    void decreaseBallCount(int decrease)
    {
        removeNumberOfObjectsFromList(decrease);
        ballRange = decrease;
        Debug.Log("Reduced number of balls being used: " + ballRange.ToString());
    }

    void addNumberOfObjectsToList(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        Debug.Log("Added Balls: " + count.ToString());
        Debug.Log("New Pooled Count: " + pooledObjects.Count.ToString());
    }

    void removeNumberOfObjectsFromList(int count)
    {
        int numToRemove = pooledObjects.Count - count;
        for (int i = 0; i < numToRemove; i++)
        {
            pooledObjects.Remove(objectToPool);
        }
        Debug.Log("Removed Balls: " + numToRemove.ToString());
        Debug.Log("New Pooled Count: " + pooledObjects.Count.ToString());
    }
}
