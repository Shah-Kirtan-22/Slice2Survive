using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGyro : MonoBehaviour
{
    private void Start()
    {
        Input.gyro.enabled = true; // Enable the gyroscope // only required for android for IOS its always on
    }

    private void Update()
    {
        this.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0); // this will give the raw value of rotation for the device // the minus sign is used to change the android's left hand system to unity's right hand system
        //this.transform.rotation = (Input.gyro.attitude);
    }
}
