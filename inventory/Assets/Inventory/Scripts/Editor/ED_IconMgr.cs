using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IconMgr))]
public class ed_IconMgr : Editor
{
    IconMgr m_IconMgr;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_IconMgr = target as IconMgr;
        GUILayout.Label("< OP >");
        if (GUILayout.Button("Setup Icon"))
        {
            m_IconMgr.Setup_DicSprite();
        }
    }
}
