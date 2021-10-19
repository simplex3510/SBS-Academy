using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(InvenData))]
class ed_InvenData : Editor
{
    InvenData m_InvenData;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_InvenData = target as InvenData;
        GUILayout.Label("-------------< OP >--------------");
        
        if (GUILayout.Button(" SaveData()"))
        {
            m_InvenData.SaveData();
        }
        if (GUILayout.Button(" LoadData()"))
        {
            m_InvenData.LoadData();
        }
        if (GUILayout.Button(" DeleteKey()"))
        {
            m_InvenData.DeleteKey();
        }
    }

    
}
