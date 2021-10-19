using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(SkinSet))]
class ed_SkinSet : Editor
{
    SkinSet m_SkinSet;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_SkinSet = target as SkinSet;
        GUILayout.Label("< OP >");
        if (GUILayout.Button("Set skin 0"))
        {
            m_SkinSet.Set_skin(0);
        }
        if (GUILayout.Button("Set skin 1"))
        {
            m_SkinSet.Set_skin(1);
        }
    }

}
