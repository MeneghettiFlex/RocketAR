using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSystem : ScriptableObject
{
    float maxFuel;
    float startingFuel;
    float currentFuel;

    public FuelSystem(float maxFuel, float startingFuel)
    {
        this.maxFuel = (maxFuel > 0) ? maxFuel : 100;
        this.startingFuel = (startingFuel >= 0) ? startingFuel : 0;
        currentFuel = startingFuel;
    }

    public void Refuel(float fuel)
    {
        currentFuel += fuel;

        if (currentFuel > maxFuel) currentFuel = maxFuel;
    }
}