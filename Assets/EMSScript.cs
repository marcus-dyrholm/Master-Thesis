using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class EMSScript : MonoBehaviour
{

    private static SerialPort port;
    public string portName = "";
    
    public void Start()
    {
        init();
        print("Init done on Serial Port: " + portName);
    }

    private void OnDestroy()
    {
        close();
    }

    protected void init()
    {
        EMSScript.port = new SerialPort();
        EMSScript.port.PortName = portName;
        EMSScript.port.BaudRate = 115200;
        EMSScript.port.ReadTimeout = 20;
        EMSScript.port.Parity = Parity.None;
        EMSScript.port.DataBits = 8;
        EMSScript.port.StopBits = StopBits.Two;
        EMSScript.port.Open();
        //print("Opening Serial Port: " + PortName);
    }
    
    protected void close()
    {
        if (EMSScript.port != null)
        {
            EMSScript.port.Close();
            EMSScript.port.Dispose();
            //print("Closed Serial Port " + RehaStimInterface.Port.PortName);
            EMSScript.port = null;
        }
    }
    public bool sendMessage(string message)
    {
        SerialPort sp = EMSScript.port;
        if (sp == null || !sp.IsOpen)
        {
            //print ("Error: Serial Port not open");
            return false;
        }
        sp.Write(message);
        //print(System.BitConverter.ToString(message));
        Debug.Log("Com port" + EMSScript.port.PortName + "Message to EMS: " + message);
        return true;
    }

    public void message(string message)
    {
        float time = Time.deltaTime;
        float timeOut = 0.05f;

        if(time >= timeOut)
        {
            sendMessage(message);
        }


        
    }

}
