using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Distribution_SO))]
public class Editor_Distribution : Editor
{
	public Distribution_SO distro;
	public List<RootTile_SO> rootTiles => distro.tileDistributionList;
	public override void OnInspectorGUI() {
		distro = distro ?? target as Distribution_SO;
		EditorUtility.SetDirty(distro);
		GUILayout.BeginVertical(GUILayout.Height(600));
		GUILayout.BeginVertical(EditorStyles.helpBox);
		EditorStyles.label.wordWrap = true;
		GUI.color = Color.red;
		EditorGUILayout.LabelField("Be sure to add the Root Tiles on the list before proceeding",GUILayout.ExpandWidth(true));
		GUI.color = Color.white;
		GUILayout.EndVertical();
		base.DrawDefaultInspector();
		GUILayout.BeginVertical(EditorStyles.helpBox);
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Build Data")) BuildData();
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
		if(distro.amounts?.Length == distro?.tileDistributionList.Count)
			DisplaySliders();
		GUILayout.EndVertical();
		EditorStyles.label.wordWrap = false;
	}


	private void DisplaySliders() {
		float screenSize = Screen.width;
		float scale(float val) => val / 100 * screenSize;
		GUILayout.BeginVertical();
		for (int i = 0; i < rootTiles.Count; i++) {
			if(i != 0)
				distro.amounts[i] = EditorGUILayout.FloatField($"{i}", distro.amounts[i], GUILayout.ExpandWidth(true));
			distro.amounts[i] = Mathf.Clamp(distro.amounts[i],0, 100);
			distro.amounts[i] = Mathf.Clamp(distro.amounts[i],
											i == 0 ? 0 : distro.amounts[i-1],
											i == rootTiles.Count - 1 ? 100 : distro.amounts[i + 1]);
		}
		float nextmin = GUILayoutUtility.GetLastRect().yMax;

		for (int i = 0; i < distro.amounts.Length; ++i) {
			float start = scale(distro.amounts[i]);
			float size = scale(i == rootTiles.Count - 1 ? 100 : distro.amounts[i + 1] - distro.amounts[i]);
			GUI.backgroundColor = new Color32(i % 2 == 0 ? (byte)255 : (byte)0, i % 3 == 0 ? (byte)255 : (byte)0, i % 4 == 0 ? (byte)255 : (byte)0, 255);
			Rect x = new Rect(start, nextmin + 5, size, 25);
			GUI.Box(x, "");
			GUI.color = Color.white;
			GUI.Label(x, $"{(i == rootTiles.Count - 1 ? 100 - distro.amounts[i] : distro.amounts[i + 1] - distro.amounts[i])}", new GUIStyle() { alignment = TextAnchor.MiddleLeft });
		}

		GUILayout.EndVertical();
	}

	private void BuildData() {
		distro.amounts = new float[rootTiles.Count];
		float defaultIncrement = 100.00f / (float)(rootTiles.Count );
		float curInc = defaultIncrement;
		for (int i = 0; i < distro.amounts.Length; i++) {
			if (i == 0) { distro.amounts[i] = 0; continue; }
			distro.amounts[i] = (int)curInc;
			Debug.Log(curInc);
			curInc += defaultIncrement;
		}
		Debug.Log("Data Built!");
	}
}
