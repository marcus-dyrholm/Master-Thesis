using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PositionTest : MonoBehaviour
{

    public int timesComplete = -1;
    public float time;

    public GameObject[] trainingObjects;

    public Transform[] targetPoss;
    public Transform sphereSpawn;
    public GameObject targetPrefab;
    public GameObject spherePrefab;

    private GameObject currentTarget;
    private GameObject currentSphere;

    public float[] steps;

    private bool startTimer;
    private bool trainingEnded;

    // times to complete 5

    private void Start()
    {
        /* int random = Random.Range(0, 5);

         currentTarget = Instantiate(targetPrefab, targetPoss[timesComplete]);
         currentSphere = Instantiate(spherePrefab, sphereSpawn);
         currentTarget.transform.localScale = new Vector3((8 - timesComplete) / 2, (8 - timesComplete) / 2, (8 - timesComplete) / 2);
        */

        steps = linspace(0.8f, 3, 6);
        Array.Reverse(steps);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            startTimer = true;
            ProgressTest();
        }

        if (startTimer)
        {
            time += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            startTimer = true;
        }

        if (time >= 240 && !trainingEnded)
        {
            trainingEnded = true;
            EndTraining();
            startTimer = false;
            time = 0;
        }
    }

    public void ProgressTest()
    {
        timesComplete++;

        Destroy(currentSphere);
        Destroy(currentTarget);

        if (timesComplete == 6)
        {
            startTimer = false;
            Debug.Log("Position test: " + time);
            return;
        }

        currentTarget = Instantiate(targetPrefab, targetPoss[timesComplete]);
        currentSphere = Instantiate(spherePrefab, sphereSpawn);

        currentTarget.transform.localScale = new Vector3(steps[timesComplete], steps[timesComplete], steps[timesComplete]);
    }

    public void EndTraining()
    {
        foreach (var obj in trainingObjects)
        {
            Destroy(obj);
        }
    }

    public static float[] linspace(float startval, float endval, int steps)
    {
        float interval = (endval / MathF.Abs(endval)) * MathF.Abs(endval - startval) / (steps - 1);
        return (from val in Enumerable.Range(0, steps)
                select startval + (val * interval)).ToArray();
    }
}
