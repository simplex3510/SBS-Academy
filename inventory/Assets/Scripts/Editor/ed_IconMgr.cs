using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(IconMgr))]
class ed_IconMgr : Editor
{
    IconMgr m_IconMgr;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_IconMgr = target as IconMgr;
        GUILayout.Label("< OP >");
        if (GUILayout.Button("Setup Icon"))
        {
            m_IconMgr.Setup_DictSprite();
        }
        //if (GUILayout.Button("Display list data ==> json"))
        //{
        //    Debug.Log(JsonUtility.ToJson(m_IconMgr.m_lstSprite));
        //}
    }

    void Setup_Icon()
    {
        //// var filepath = "Assets/01 GraphicResources/_Resources/Main_UI/character/20001"; // path to texture containing sprites.
        //string filepath = Application.dataPath +"/" + str_path;
        //Debug.Log(" filepath:" + filepath);
        //string[] filePaths = Directory.GetFiles(filepath, "*.png");
        //Debug.Log(" filePaths:" + filePaths.Length);

        ////Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(filePaths[0]);

        //if (filePaths != null && filePaths.Length > 0)
        //{
        //    m_IconDictionary.m_dicIcon.Clear();

        //    foreach (string path_tmp in filePaths)
        //    {
        //        Debug.Log("path_tmp:" + path_tmp);
        //        string sub_path = path_tmp.Substring(path_tmp.IndexOf("Assets"));
        //        Debug.Log("path_tmp.Substring:" + sub_path);

        //        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(sub_path); // as Sprite;
                
        //        m_IconDictionary.m_dicIcon.Add(sprite.name, sprite);
        //    }
        //}
    }
}
