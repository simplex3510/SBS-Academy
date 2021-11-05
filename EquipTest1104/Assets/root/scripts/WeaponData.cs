using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public string m_weaponName;
    public bool m_isbothHands = false;

    public void Set_DragData()
    {
        GameMgr.instance.m_currentDragData = this;
    }
}
