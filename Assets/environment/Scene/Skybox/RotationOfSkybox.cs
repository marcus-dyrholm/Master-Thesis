using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfSkybox : MonoBehaviour
{
    public float speed;
    private Vector3 Sun;
    public Transform SunG;
    public float SunStart;


    // Start is called before the first frame update
    void Start()
    {
        SunStart = 173.8f;
    }

    // Update is called once per frame
    void Update()
    {
         
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
        Sun.y = SunStart + Time.time * speed;
        Sun.x = 15.9f;

        Vector3 newPosition = Sun;
        SunG.eulerAngles = newPosition;


    }
}
