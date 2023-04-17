using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMaster : MonoBehaviour
{
    private List<GameObject> cubes;

    public CollisionChecker[] CollisionCheckers;

    public GameObject[] objectiveCanvasses;

    public GameObject completedCanvas;

    public TutorialObjects tutorialObjects;

    private float time;

    public float timeCutoff = 5.0f;

    private bool objectiveComplete;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (CollisionCheckers[0].cubesIsColliding && CollisionCheckers[1].cubesIsColliding && CollisionCheckers[2].cubesIsColliding)
        {
            objectiveComplete = true;

        }
        if (objectiveComplete)
        {
            time += Time.deltaTime;
            completedCanvas.SetActive(true);
            for (int i = 0; i < objectiveCanvasses.Length; i++)
            {
                objectiveCanvasses[i].SetActive(false);
            }

            if (time >= timeCutoff)
            {
                completedCanvas.SetActive(false);
                for (int i = 0; i < objectiveCanvasses.Length; i++)
                {
                    objectiveCanvasses[i].SetActive(true);
                    CollisionCheckers[i].cubesIsColliding = false;
                }
                tutorialObjects.CreateCubes();
                time = 0;
                objectiveComplete = false;
            }
        }
    }
}
