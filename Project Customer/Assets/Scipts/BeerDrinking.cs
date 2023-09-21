using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeerDrinking : MonoBehaviour
{

    private float drunkness = 0.0f;
    private int beerDrunk = 0;
    private bool maxDrunkness = false;
    private float horizontalOffset = 0.0f;
    private float horizontalOffsetTarget = 0.0f;
    private float lastBeerDrunk = 0.0f;
    private float lastDirectionChange = 0.0f;
    public float timeBetweenEachBeerInSeconds = 5.0f;
    public float timeBetweenNewDirectionInSeconds = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        drunkness = 0.0f;
        beerDrunk = 0;
        horizontalOffset = 0.0f;
        horizontalOffsetTarget = 0.0f;
        lastBeerDrunk = 0.0f;
        lastDirectionChange = 0.0f;
        maxDrunkness = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!maxDrunkness) {
            Drink();
        }
        changeDirection();
        changeCurrentHorizontalOffset();
    }

    void Drink() {
        lastBeerDrunk += Time.deltaTime;
        if (lastBeerDrunk < timeBetweenEachBeerInSeconds) {
            return;
        }
        lastBeerDrunk = 0.0f;
        beerDrunk += 1;
        drunkness = 1 - (float)Math.Pow(0.95, beerDrunk);
        Debug.Log("Drunkness: " + drunkness);
        
    }

    void changeDirection() {
        lastDirectionChange += Time.deltaTime;
        if (lastDirectionChange < timeBetweenNewDirectionInSeconds) {
            return;
        }
        lastDirectionChange = 0.0f;
        horizontalOffsetTarget = UnityEngine.Random.Range(-drunkness, drunkness);
    }

    void changeCurrentHorizontalOffset() {
        // Mathf.Lerp is doing a linear interpolation between two values which means that the value will change smoothly for example from 0.0f to 1.0f in 1 second the first value is the start value the second value is the end value  the third value is the time it takes to go from the start value to the end value        
        float lerpTimeValue = (1 / timeBetweenNewDirectionInSeconds) * Time.deltaTime;
        horizontalOffset = Mathf.Lerp(horizontalOffset, horizontalOffsetTarget, lerpTimeValue);
    }

    public float getBeerDrunk() {
        return beerDrunk;
    }
    
    public float getHorizontalOffset() {
        return horizontalOffset;
    }

    public float getDrunkness() {
        return drunkness;
    }
}
