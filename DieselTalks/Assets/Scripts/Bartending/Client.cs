using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField] private int 
        variationThreshold = 5;

    [SerializeField] private DrinkProperties desiredDrinkValues;

    public int EnjoymentLevel(DrinkProperties checkedDrink)
    {
        int level = 0;

        for(int i = 0; i < desiredDrinkValues.Flavours.Length; i++)
        {
            if (desiredDrinkValues.Flavours[i] - checkedDrink.Flavours[i] < variationThreshold) level++;
        }

        return level;

    }
}
