using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new();
    [SerializeField] private List<TValue> values = new();

    public void OnAfterDeserialize()
    {
        this.Clear();

        if (keys.Count != values.Count) 
            Debug.LogError
            (
                $"Chaves e valores do Dicionario nao tem o mesmo tamanho. " +
                $"Chaves.Length: {keys.Count} " +
                $"Valores.Length: {values.Count}"
            );

        for (int i = 0; i < keys.Count; i++) 
        {
            this.Add(keys[i], values[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        foreach (KeyValuePair<TKey, TValue> kvp in this)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }
}
