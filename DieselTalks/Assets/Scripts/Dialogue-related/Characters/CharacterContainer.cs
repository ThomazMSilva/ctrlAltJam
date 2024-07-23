using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CharacterContainer : ScriptableObject
{
    public List<CharacterProperties> characters = new();

    public CharacterProperties GetCharacter(CharacterKey key)
    {
        CharacterProperties ch = characters.Find(obj => obj.characterName == key);

        return ch ?? characters[0];
    }
}
