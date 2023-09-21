using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FuelCanisterScript : MonoBehaviour
{
    private float minFuelAngle = 65, maxFuelAngle = -65;
    public AutoAccelerate myCar;
    private float pointerAngle = 0;

    //Image pointer = GetComponent<Image>();
    public Image pointer;

    void Start()
    {
        
    }

    void Update()
    {
       // pointerAngle = (myCar.carFuel * (minFuelAngle - maxFuelAngle)) / 100;
        //pointer.rotate.z = 65 + pointerAngle;
        pointer.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 65 - pointerAngle);
        //pointer.transform.Rotate(
    }
}
