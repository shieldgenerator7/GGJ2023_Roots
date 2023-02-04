using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TreeGameObject))]
public class TreeGameObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TreeGameObject tgo = (TreeGameObject)target;
        if (GUILayout.Button("Damage"))
        {
            tgo.treeHealth.Health -= tgo.maxHealth/10;
        }
        if (GUILayout.Button("Heal"))
        {
            tgo.treeHealth.Health += tgo.maxHealth / 10;
        }
        GUILayout.Label($"{tgo.treeHealth.Health}");
    }
}
