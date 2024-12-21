﻿using System;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public static class UsualVector {

    public static float DotProduction(this Vector2 a, Vector2 b) => a.x * b.x + a.y * b.y;
    public static float DotProduction(this Vector3 a, Vector3 b) => a.x * b.x + a.y * b.y;

    public static bool Approximately(this Vector2 a, Vector2 b) =>
        Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y);
    
    public static bool Approximately(this Vector3 a, Vector3 b) =>
            Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y) && Mathf.Approximately(a.z, b.z);

    public static Vector2 ToVector2(this Vector3 target) => new(target.x, target.y);
    public static Vector3 ToVecotr3(this Vector2 target) => new(target.x, target.y, 0);
}