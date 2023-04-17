using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class EMSScript2 : MonoBehaviour
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
        EMSScript2.port = new SerialPort();
        EMSScript2.port.PortName = portName;
        EMSScript2.port.BaudRate = 115200;
        EMSScript2.port.ReadTimeout = 20;
        EMSScript2.port.Parity = Parity.None;
        EMSScript2.port.DataBits = 8;
        EMSScript2.port.StopBits = StopBits.Two;
        EMSScript2.port.Open();
        //print("Opening Serial Port: " + PortName);
    }
    
    protected void close()
    {
        if (EMSScript2.port != null)
        {
            EMSScript2.port.Close();
            EMSScript2.port.Dispose();
            //print("Closed Serial Port " + RehaStimInterface.Port.PortName);
            EMSScript2.port = null;
        }
    }
    public bool sendMessage(string message)
    {
        SerialPort sp = EMSScript2.port;
        if (sp == null || !sp.IsOpen)
        {
            //print ("Error: Serial Port not open");
            return false;
        }
        sp.Write(message);
        //print(System.BitConverter.ToString(message));
        Debug.Log("Com port" + EMSScript2.port.PortName + "Message to EMS: " + message);
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
