using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APark : MonoBehaviour
{
    AudioSource Park;

    [Range(0f, 1f)]
    public float Volume;
    public Transform ViewD;
    public float VolumeSpeed;
    public float TrackerOfVolume;

    void Start()
    {
        VolumeSpeed = 0.01f;
        ViewD = Camera.main.transform;
        Volume = 0.5f;
        Park = GetComponent<AudioSource>();
        Park.Play();
        Park.volume = Volume;

    }

    // Update is called once per frame
    void Update()
    {
        Park.volume = Volume;

        SoundManager();
        SoundAdjuster();

    }

    public void SoundManager()
    {


        if (ViewD.rotation.y > -180 && ViewD.rotation.y < 0)
        {
            TrackerOfVolume += Time.deltaTime * VolumeSpeed;
            if (TrackerOfVolume > 1)
            {
                TrackerOfVolume = 1;
            }
        }

        if (ViewD.rotation.y > 0 && ViewD.rotation.y < 180)
        {
            TrackerOfVolume -= Time.deltaTime * VolumeSpeed;
            if (TrackerOfVolume < 0)
            {
                TrackerOfVolume = 0;
            }
        }

    }

    public void SoundAdjuster()
    {
        if (TrackerOfVolume > Volume)
        {
            Volume += Time.deltaTime * VolumeSpeed;
        }

        if (TrackerOfVolume < Volume)
        {
            Volume -= Time.deltaTime * VolumeSpeed;
        }
    }

}
