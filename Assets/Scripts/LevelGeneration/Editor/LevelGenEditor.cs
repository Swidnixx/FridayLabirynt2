using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))]
public class LevelGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelGenerator gen = (LevelGenerator)target;

        if(GUILayout.Button("Generate"))
        {
            gen.GenerateLevel();
        }

        if(GUILayout.Button("Clear"))
        {
            gen.ClearLevel();
        }
    }
}
