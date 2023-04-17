using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ambulance ambulance;
    public List<GameObject> ambulanceWaypoints;
    public GameObject[] snapToContainers;
    public GameObject[] snapToConcreate;
    public GameObject[] fire;

    public GameObject[] objectives;

    private bool allFireInactive = true;

    // Update is called once per frame

    private void Start()
    {
        ambulanceWaypoints = ambulance.waypoints;
        fire = GameObject.FindGameObjectsWithTag("Fire");
    }

    void Update()
    {
        if (ambulance.current == 4)
        {
            
            objectives[1].SetActive(true);
            ambulance.speed = 0;
            if (snapToContainers[0].activeInHierarchy && snapToContainers[1].activeInHierarchy && snapToContainers[2].activeInHierarchy)
            {

                ambulance.speed = 5;
                objectives[1].SetActive(false);
                objectives[0].SetActive(false);
            }
        }

        if (ambulance.current == 5)
        {
            objectives[2].SetActive(true);
            objectives[3].SetActive(true);
            ambulance.speed = 0;
            if (snapToConcreate[0].activeInHierarchy && snapToConcreate[1].activeInHierarchy)
            {
                objectives[2].SetActive(false);
                objectives[3].SetActive(false);
                ambulance.speed = 5;
            }
        }

        if (ambulance.current == 9)
        {
            ambulance.speed = 0;
            objectives[4].SetActive(true);
            objectives[5].SetActive(true);
            for (int i = 0; i < fire.Length; i++)
            {
                if (fire[i].activeInHierarchy)
                {
                    allFireInactive = false;
                    break;
                }
                else
                {
                    allFireInactive = true;
                }



            }
            if (allFireInactive)
            {
                objectives[4].SetActive(true);
                objectives[5].SetActive(false);
                ambulance.speed = 5;
            }
        }

        if (ambulance.current == 10)
        {
            ambulance.speed = 0;
            //activate questionnaire
        }

    }
}
