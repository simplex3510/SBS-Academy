using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemMgr))]
public class ed_ItemMgr : Editor
{
    ItemMgr m_ItemMgr;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_ItemMgr = target as ItemMgr;
        GUILayout.Label("< OP >");
        if (GUILayout.Button("Display Json string"))
        {
            Debug.Log(JsonUtility.ToJson(m_ItemMgr.m_infoTable));
        }
        if (GUILayout.Button("Import Json File"))
        {
            m_ItemMgr.m_infoTable = JsonUtility.FromJson<ItemInfoTable>(m_ItemMgr.m_jsonInfoFile.text);
        }
        if(GUILayout.Button("Setup Item Book UI"))
        {
            m_ItemMgr.Setup_itemBookContent();
        }
    }
}
