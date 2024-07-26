using System;
using UnityEngine;

[Serializable]
public class SavedData
{
    public int level;

    public float generalVolume;
    public float sfxVolume;
    public float musicVolume;
    public float voicesVolume;

    public SerializableDictionary<CharacterKey, int> characterProximityLevels;

    public string[] savedDrinks;
    public bool[] drinkStates;
    
    //Constructor
    public SavedData()
    {
        level = 0;
        characterProximityLevels = new SerializableDictionary<CharacterKey, int>();

        generalVolume = 0.5f;
        sfxVolume = 0.5f;
        musicVolume = 0.5f;
        voicesVolume = 0.5f;

        drinkStates = new bool[16];
        for (int i = 0; i < drinkStates.Length; i++)
            drinkStates[i] = false;
        
    }
}
