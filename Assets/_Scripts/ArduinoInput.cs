using UnityEngine;
using System.IO.Ports;

public class ArduinoInput : MonoBehaviour
{
    SerialPort port;
    public string portName = "COM10"; // Change if needed
    public int baudRate = 9600;

    public WaterController waterController;

    void Start()
    {
        port = new SerialPort(portName, baudRate);
        port.ReadTimeout = 50;

        try
        {
            port.Open();
        }
        catch
        {
            Debug.LogError("Can't open serial port!");
        }
    }

    void Update()
    {
        if (port.IsOpen)
        {
            try
            {
                string data = port.ReadLine().Trim();

                if (data == "0")   // Water detected
                {
                    waterController.JumpFromArduino();
                }
            }
            catch { }
        }
    }

    void OnApplicationQuit()
    {
        if (port.IsOpen) port.Close();
    }
}


