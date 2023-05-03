using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public int participantID;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        participantID = 0;
    }

    private void Update()
    {
        if (participantID == 0)
        {
            Debug.LogError("participant id is 0");
        }
    }


    public void saveData(float completionTime)
    {
        //SaveData data = new SaveData{ participantID, completionTime };
       // string jsonData = JsonUtility.ToJson(data);
      //  System.IO.File.WriteAllText(Application.persistentDataPath + "/TestData", jsonData);
    }
}

public class SaveData
{
    int participantID;
    float completionTime;
}
