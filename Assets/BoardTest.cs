using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTest : MonoBehaviour
{

    public int collidingObjects;
    public float time;
    public GameObject[] objects;

    private bool startTimer;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            foreach (var obj in objects)
            {
                obj.SetActive(true);
                startTimer = true;
            }
        }

        if (startTimer)
        {
            time += Time.deltaTime;
        }

        if (collidingObjects == 5 && startTimer)
        {
            startTimer = false;
            Debug.Log("Board test: " + time);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.name)
        {
            case "Arch":
                SetMaterialColor(other, Color.green);
                collidingObjects++;
                break;
            case "Circle":
                SetMaterialColor(other, Color.green);
                collidingObjects++;
                break;
            case "Cube":
                SetMaterialColor(other, Color.green);
                collidingObjects++;
                break;
            case "Cylinder":
                SetMaterialColor(other, Color.green);
                collidingObjects++;
                break;
            case "Triangle":
                SetMaterialColor(other, Color.green);
                collidingObjects++;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Arch":
                SetMaterialColor(other, Color.gray);
                collidingObjects--;
                break;
            case "Circle":
                SetMaterialColor(other, Color.gray);
                collidingObjects--;
                break;
            case "Cube":
                SetMaterialColor(other, Color.gray);
                collidingObjects--;
                break;
            case "Cylinder":
                SetMaterialColor(other, Color.gray);
                collidingObjects--;
                break;
            case "Triangle":
                SetMaterialColor(other, Color.gray);
                collidingObjects--;
                break;
        }
    }


    public void SetMaterialColor(Collider col, Color color)
    {
        col.transform.GetComponent<Renderer>().material.SetColor("_BaseColor", color);
    }
}
