using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[Serializable]
public class SerializableDictionary<K, V> {

    [Serializable]
    public class Datas {
        [SerializeField] private K key;
        public K Key {
            get => key;
        }
        
        [SerializeField] private V value;
        public V Value {
            get => value;
        }
    }
    
    [SerializeField] private List<Datas> datas = new();

    public Dictionary<K, V> Data { get; private set; } = new();

    public void Convert() {

        foreach (var data in datas) { 
            Data.Add(data.Key, data.Value);
        }
    }

    public SerializableDictionary() {
        Convert();
    }
}