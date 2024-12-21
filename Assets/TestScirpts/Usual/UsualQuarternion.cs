using Unity.Mathematics;
using UnityEngine;

public static class UsualQuarternion {

    public static Quaternion ZRotation(float degree)
        => Quaternion.Euler(0, 0, degree);

    public static Quaternion Multiple(this Quaternion degree, float multiple)
        => (degree.eulerAngles * multiple).ToQuaternion();

    public static Quaternion Add(this Quaternion currentDegree, Quaternion addDegree)
        => (currentDegree.eulerAngles + addDegree.eulerAngles).ToQuaternion();
    public static Quaternion ToQuaternion(this Vector3 degree)
        => Quaternion.Euler(degree.x, degree.y, degree.z);
}