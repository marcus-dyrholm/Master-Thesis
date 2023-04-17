using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance : MonoBehaviour
{
    public GameObject waypointContainer;
    public List<GameObject> waypoints;
    
    public int current;
    float rotSpeed;
    public float speed;
    float WPradius = 1;
    public bool isIntrigger = false;

 Vector3 currentAngle;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < waypointContainer.transform.childCount; i++)
        {
            waypoints.Add(waypointContainer.transform.GetChild(i).gameObject);
        }
    currentAngle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Count)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

        var targetRotation = Quaternion.LookRotation(waypoints[current].transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        speed = 0;
        isIntrigger = true;
    }
}
