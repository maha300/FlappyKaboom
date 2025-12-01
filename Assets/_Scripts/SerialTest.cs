using UnityEngine;
using System.IO.Ports;

public class SerialTest : MonoBehaviour
{
    SerialPort port;

    void Start()
    {
        port = new SerialPort("COM10", 9600); 
        port.ReadTimeout = 50;

        try
        {
            port.Open();
            Debug.Log("Serial port opened!");
        }
        catch
        {
            Debug.LogError("Could NOT open serial port!");
        }
    }

    void Update()
    {
        if (port != null && port.IsOpen)
        {
            try
            {
                if (port.BytesToRead > 0)
                {
                    string value = port.ReadLine().Trim();
                    Debug.Log("Arduino says: " + value);
                }
            }
            catch { }
        }
    }

    private void OnApplicationQuit()
    {
        if (port != null && port.IsOpen)
            port.Close();
    }
}
