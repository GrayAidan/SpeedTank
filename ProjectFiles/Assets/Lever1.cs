using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    float Potentiometer;
    public float angle = 10;
    public float max = 1;
    public float min = 1000;
    // Start is called before the first frame update
    void Start()
    {
        Uduino.UduinoManager.Instance.pinMode(Uduino.AnalogPin.A1, Uduino.PinMode.Input);
    }

    // Update is called once per frame
    void Update()
    {
        Potentiometer = Uduino.UduinoManager.Instance.analogRead(Uduino.AnalogPin.A1);

        float angleTarget = (Potentiometer - min) / (float)(max - min);
        calibrate();

        angle = Mathf.Lerp((float)angle, (float)angleTarget, 0.1f);

        //print(angle);

        transform.rotation = new Quaternion(angle - 1, 0, 0, 1);
    }

    void calibrate()
    {

        if (Time.frameCount > 120)
        {
            if (max < Potentiometer)
            {
                max = Potentiometer;
            }

            if (min > Potentiometer)
            {
                min = Potentiometer;
            }
        }

        if (float.IsNaN(angle))
        {
            angle = 1;
        }
    }
}

