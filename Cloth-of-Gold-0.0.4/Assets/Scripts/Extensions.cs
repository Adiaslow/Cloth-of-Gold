using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Extensions
{
    public static void Populate<T>(this T[] arr, T value)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = value;
        }
    }

    public static Vector3Int With(this Vector3Int obj, int? x = null, int? y = null, int? z = null) =>
        new Vector3Int(x ?? obj.x, y ?? obj.y, z ?? obj.z);
}