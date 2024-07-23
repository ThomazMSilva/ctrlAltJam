using System;

[Serializable]
public class SavedData
{
    public int
        level,
        characterProximity1,
        characterProximity2;

    public SerializableDictionary<CharacterKey, int> characterLevels;
    
    //Constructor
    public SavedData()
    {
        level = 0;
        characterProximity1 = 0;
        characterProximity2 = 0;
        characterLevels = new SerializableDictionary<CharacterKey, int>();
    }
}
