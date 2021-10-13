using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SkinSet))]
public class IconMgr : Editor
{
    IconMgr m_IconMgr;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_IconMgr = target as IconMgr;
        GUILayout.Label("< OP >");
        if (GUILayout.Button("Set Icon"))
        {
            m_IconMgr.Set_skin(0);
        }
    }
}
