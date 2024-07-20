using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CharacterManager : ScriptableObject
{
    public List<CharacterProperties> characters = new();

    public CharacterProperties GetCharacter(CharacterKey key)
    {
        return characters.Find(obj => obj.characterName == key); 
    }
}
