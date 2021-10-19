using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(Panel_Inventory))]
class ed_Inventory : Editor
{
    Panel_Inventory m_Inventory;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_Inventory = target as Panel_Inventory;
        GUILayout.Label("-------------< OP >--------------");
        
        if (GUILayout.Button("Setup Inventory UI"))
        {
            m_Inventory.OnEnable();
        }

    }

    
}
