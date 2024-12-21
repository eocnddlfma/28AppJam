using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class SerializableDictionary<K, V>: Dictionary<K, V>, ISerializationCallbackReceiver {

    [SerializeField] private List<K> keys;
    [SerializeField] private List<V> values;

    public void OnBeforeSerialize() {

        keys.Clear();
        values.Clear();

        foreach (KeyValuePair<K, V> pair in this) {

            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize() {

        this.Clear();

        for (int i = 0, size = keys.Count; i < size; i++) {

            this.Add(keys[i], values[i]);
        }
    }
}