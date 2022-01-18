using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(CloudGenerator))]

public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CloudGenerator mapGen = (CloudGenerator)target;

        if(DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.GenerateMap();
            }
        }

        if (GUILayout.Button("Generate"))
        {
            mapGen.GenerateMap();
        }
    }
}


