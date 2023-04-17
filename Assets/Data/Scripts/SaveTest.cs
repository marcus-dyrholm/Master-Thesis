using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveTest : MonoBehaviour
{
    public SaveObject so;

    public void SaveButtonA()
    {
        SaveManager.Save(so);
    }
}
