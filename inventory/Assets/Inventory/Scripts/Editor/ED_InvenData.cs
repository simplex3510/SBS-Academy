using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(InvenData))]
public class ED_InvenData : Editor
{
    DrawDefaultInspector();
    m_InvenData = target as InvenData;
    GUILayout.Label("<OP>");

    if(GUILayout.Button("SaveData()"))
    {
        
    }
}
