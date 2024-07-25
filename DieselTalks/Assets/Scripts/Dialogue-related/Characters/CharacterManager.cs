using System;
using UnityEngine;

public class CharacterManager : MonoBehaviour, ISavable
{
    public SerializableDictionary<CharacterKey, int> characterList;

    private void Awake()
    {
        for (int i = 0; i < Enum.GetNames(typeof(CharacterKey)).Length; i++)
        {
            characterList.Add((CharacterKey)i, 0);
        }
    }

    public void ChangeProximityLevel(CharacterKey character, int proximityLevel)
    {
        characterList[character] = proximityLevel;
        Debug.Log($"Mudou a proximidade de {character} em {proximityLevel}. Agora é {characterList[character]}");
    }

    public void LoadData(SavedData data)
    {
        characterList = data.characterProximityLevels;
    }

    public void SaveData(ref SavedData data)
    {
        data.characterProximityLevels = characterList;
    }
}
