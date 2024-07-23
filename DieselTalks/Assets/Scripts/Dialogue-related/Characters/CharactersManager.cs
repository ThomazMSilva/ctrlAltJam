using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharactersManager : MonoBehaviour, IDataHandler
{
    public SerializableDictionary<CharacterKey, int> characterList;

    private void Awake()
    {
        for (int i = 0; i < Enum.GetNames(typeof(CharacterKey)).Length; i++)
        {
            characterList.Add((CharacterKey)i, 0);
        }
    }

    public void ChangeProximityLevel(CharacterKey character, int level)
    {
        characterList[character] = level;
    }

    public void LoadData(SavedData data)
    {
        characterList = data.characterLevels;
    }

    public void SaveData(ref SavedData data)
    {
        data.characterLevels = characterList;
    }
}
