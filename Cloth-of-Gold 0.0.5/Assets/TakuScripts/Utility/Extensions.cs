using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Extensions
{
	public static void Populate<T>(this T[] arr, T value) {
		for (int i = 0; i < arr.Length; i++) {
			arr[i] = value;
		}
	}

	public static void Populate<T>(this T[] arr, T[] value) {
		for (int i = 0; i < arr.Length; i++) {
			arr[i] = value[Random.Range(0, value.Length)];
		}
	}

	public static float scale(this float x, float in_min, float in_max, float out_min, float out_max) {
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}

	public static int scale(this int x, int in_min, int in_max, int out_min, int out_max) {
		return (int)((x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min);
	}

	public static Vector3Int With(this Vector3Int obj, int? x = null, int? y = null, int? z = null) =>
		new Vector3Int(x ?? obj.x, y ?? obj.y, z ?? obj.z);
}
