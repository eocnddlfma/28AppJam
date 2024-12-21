using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BlockGenerator: MonoBehaviour {
    private const int size = 30;
    private readonly Vector2Int defaultPlayRange = new(7,5);
    private static GameObject folder = null;
    
    [SerializeField] private SerializableDictionary<MineralType, MineralScriptable> matchInfoType = new();
    private List<MineralType> mineralPercentList = new();
    private void Awake() {

        if (folder == null) {
        
            folder = new GameObject();
            folder.transform.position = Vector3.zero;
            folder.name = "folder";
        }
        
        matchInfoType.Convert();
        foreach (var mineral in matchInfoType.Data) {

            var count = mineral.Value.Percent;
            while (count-- > 0) {
                
                mineralPercentList.Add(mineral.Key);
            }
        }
        
        for (int i = -size; i <= size; i++) {
            for (int j = -size; j <= size; j++) {

                if (-defaultPlayRange.x <= i && i <= defaultPlayRange.x && -defaultPlayRange.y <= j && j <= defaultPlayRange.y)
                    continue;
                
                int index = Random.Range(0, mineralPercentList.Count);
                var info = matchInfoType.Data[mineralPercentList[index]];

                if (info.Prefab != null) {
                    
                    Instantiate(info.Prefab, folder.transform).GetComponent<Block>()
                        .Set(new(i,j), info.JuwelType, mineralPercentList[index]);
                }
            }
        }
    }
}