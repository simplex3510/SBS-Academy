using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(Player))]
class ed_Player : Editor
{
    Player m_Player;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        m_Player = target as Player;
        GUILayout.Label("< OP >");
        if (GUILayout.Button("Equip 2HandSword"))
        {
            m_Player.Click_equip2HandSword();
        }
        if (GUILayout.Button("Equip Unarmed"))
        {
            m_Player.Click_equipUnarmed();
        }
        if (GUILayout.Button("Equip sword L"))
        {
            m_Player.Click_equipSword_L();
        }
        if (GUILayout.Button("Equip sword R"))
        {
            m_Player.Click_equipSword_R();
        }
    }

}
