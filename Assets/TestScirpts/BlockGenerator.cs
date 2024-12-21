﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BlockGenerator: MonoBehaviour {
    [SerializeField]private int size = 30;

    [SerializeField] private SerializableDictionary<MineralType, MineralScriptable> matchInfoType = new();
    private List<MineralType> mineralPercentList = new();
    private void Awake() {

        matchInfoType.Convert();
        foreach (var mineral in matchInfoType.Data) {

            var count = mineral.Value.Percent;
            while (count-- > 0) {
                
                mineralPercentList.Add(mineral.Key);
            }
        }
        
        for (int i = -size; i <= size; i++) {
            for (int j = -size; j <= size; j++) {

                int index = Random.Range(0, mineralPercentList.Count);
                var info = matchInfoType.Data[mineralPercentList[index]];

                if (info.Prefab != null) {
                    
                    Instantiate(info.Prefab).GetComponent<Block>()
                        .Set(new(i,j), info.JuwelType);
                }
            }
        }
    }
}