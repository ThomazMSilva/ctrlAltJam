using Unity.Properties;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;


[System.Serializable]
public class DrinkProperties
{

    /// <summary>
    /// 0 = sour<br></br>
    /// 1 = bitter<br></br>
    /// 2 = sweet<br></br>
    /// 3 = temperature
    /// </summary>
    public float[] Flavours = new float[4];
    
    public float SournessValue
    {
        get => Flavours[0];
        set => Flavours[0] = value;
    }

    public float BitternessValue
    {
        get => Flavours[1];
        set => Flavours[1] = value;
    }

    public float SweetnessValue
    {
        get => Flavours[2];
        set => Flavours[2] = value;
    }

    public float TemperatureValue
    {
        get => Flavours[3];
        set => Flavours[3] = value;
    }

    public static DrinkProperties Combine(DrinkProperties a, DrinkProperties b)
    {
        var combined = new DrinkProperties();
        for (int i = 0; i < a.Flavours.Length; i++)
        {
            combined.Flavours[i] = a.Flavours[i] + b.Flavours[i];
        }
        return combined;
    }

    public void ResetValues()
    {
        for (int i = 0; i < Flavours.Length; i++) { Flavours[i] = 0f; }
    }
}
public enum Flavour
{
    Sourness,
    Bitterness,
    Sweetness,
    Temperature
}

public class Drink : MonoBehaviour
{
    public DrinkProperties currentDrink;
    
    /*
     * //[SerializeField] private DrinkFlavourValues[] correctFlavour = new DrinkFlavourValues[3];

    //public FlavourArgumentEvent OnCustomButtonPressed;

    //public FloatArgumentEvent OnModify;*/

    public void AddFlavour(DrinkProperties newValues)
    {
        currentDrink = DrinkProperties.Combine(currentDrink, newValues);
    }

    public void AddSpecificFlavour(Flavour flavour, float amount)
    {
        switch (flavour)
        {
            case Flavour.Sourness:
                currentDrink.SournessValue += amount;
                break;
            case Flavour.Bitterness:
                currentDrink.BitternessValue += amount;
                break;
            case Flavour.Sweetness:
                currentDrink.SweetnessValue += amount;
                break;
            case Flavour.Temperature:
                currentDrink.TemperatureValue += amount;
                break;
        }
    }

}



