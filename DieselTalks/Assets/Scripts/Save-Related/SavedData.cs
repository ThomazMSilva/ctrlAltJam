using System;
using UnityEngine;

[Serializable]
public class SavedData
{
    public int
        level;

    public SerializableDictionary<CharacterKey, int> characterProximityLevels;


    public string[] savedDrinks;
    public bool[] drinkStates;
    
    //Constructor
    public SavedData()
    {
        level = 0;
        characterProximityLevels = new SerializableDictionary<CharacterKey, int>();
        
        drinkStates = new bool[16];
        for (int i = 0; i < drinkStates.Length; i++)
            drinkStates[i] = false;
        
    }
}
