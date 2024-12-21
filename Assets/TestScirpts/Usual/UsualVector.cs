using System;
using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public static class UsualVector {

    public static float DotProduction(this Vector2 a, Vector2 b) => a.x * b.x + a.y * b.y;
    public static float DotProduction(this Vector3 a, Vector3 b) => a.x * b.x + a.y * b.y;

    public static bool Approximately(this Vector2 a, Vector2 b) =>
        Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y);
    
    public static bool Approximately(this Vector3 a, Vector3 b) =>
            Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y) && Mathf.Approximately(a.z, b.z);


    public static float ToDegree(this Vector2 direction) =>
        Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
    
    public static Vector2 Todirection(this float degree) =>
        new(Mathf.Sin(degree * Mathf.Deg2Rad), Mathf.Cos(degree * Mathf.Deg2Rad));
    
    public static Vector2 ToVector2(this Vector3 target) => new(target.x, target.y);
    public static Vector3 ToVecotr3(this Vector2 target) => new(target.x, target.y, 0);

    public static float Distance(this Vector2 target) 
        => target.magnitude;

    public static Vector2 SetPower(this Vector2 target, float power) {
        var dist = target.magnitude;
        if (dist == 0) {
            target = Vector2.up;
            dist = target.Distance();
        }
        return target / target.Distance() * power;
    }
}