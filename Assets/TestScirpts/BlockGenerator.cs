using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BlockGenerator: MonoBehaviour {
    private const int size = 30;

    [SerializeField] private Dictionary<MineralType, MineralScriptable> matchInfoType = new();
    [SerializeField] private List<MineralType> mineralList = new();
    private List<MineralType> mineralPercentList = new();
    private void Awake() {

        foreach (var mineral in mineralList) {

            var count = matchInfoType[mineral].Percent;
            while (count-- > 0) {
                
                mineralPercentList.Add(mineral);
            }
        }
        
        for (int i = -size; i <= size; i++) {
            for (int j = -size; j <= size; j++) {

                int index = Random.Range(0, matchInfoType.Count);
                var info = matchInfoType[mineralList[index]];

                if (info.Prefab != null) {
                    
                    Instantiate(info.Prefab).GetComponent<Block>()
                        .Set(new(i,j), info.JuwelType);
                }
            }
        }
    }
}