using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFill : MonoBehaviour
{

    public Animator anim;
    public float maxWeight = 10;
    private bool increaseWeight;
    public float minWeight = 3;
    private float time;
    private Rigidbody rigidbody;
    private bool decreaseWeight;
    public GameObject waterSpout;

    public WaterPipe waterPipe;

    public bool waterIsActive;
    // Start is called before the first frame update
    void Start()
    {
        time = this.GetComponent<Rigidbody>().mass;
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(increaseWeight == true)
        {
            time += Time.deltaTime;

            rigidbody.mass = time;
            anim.SetFloat("Speed",1);
            
            
            if (time >= maxWeight)
            {
                increaseWeight = false;
            }
        }
        else if(decreaseWeight == true)
        {
            time -= (Time.deltaTime / 4);
            rigidbody.mass = time;
            anim.SetFloat("Speed", -0.25f);
            

            if(time <= minWeight)
            {
                decreaseWeight = false;
                waterSpout.SetActive(false);
                waterIsActive = false;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "WaterTower" && waterPipe.waterIsFlowing)
        {
            
            increaseWeight = true;
            decreaseWeight = false;
            waterSpout.SetActive(true);
            waterIsActive = true;
        }
    }

    void OnTriggerExit()
    {
        
        
        
        
    }
}
