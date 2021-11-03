using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public string m_weaponName;
    public bool m_isBothHands = false;

    public void Set_DragData()
    {
        GameMgr.instance.Get_player().m_dragData = this;
    }
}
