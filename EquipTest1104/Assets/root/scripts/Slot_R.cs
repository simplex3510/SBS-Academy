using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_R : SlotHand
{
    public Slot_L m_slot_L;

    public void Click_Unequip()
    {
        GameMgr.instance.Get_player().Click_rightUnequip();
        base.Unequip();
    }

    public override void OnDrop(Image _icon)
    {
        Player p = GameMgr.instance.Get_player();
        if (p.Equip_R_currentDragData() == true)
        {
            if (_icon != null && _icon.sprite != null)
            {
                // ��� ���� UIó��.
                m_icon.sprite = _icon.sprite;
                m_equipWeaponData = GameMgr.instance.m_currentDragData;
                //=========================

                // �� ��� ��տ� �ΰ�?
                if(m_equipWeaponData.m_isbothHands)
                {
                    // �޼� ��� ����
                    m_slot_L.Unequip();
                }
                else
                // �޼� ��� �Ǵ� ó��. 
                if (m_slot_L.m_equipWeaponData != null
                    && m_slot_L.m_equipWeaponData.m_isbothHands == true
                    )
                {
                    // ��� ���� UI ó��.
                    m_slot_L.Unequip();
                }
            }
            else
            {
                Debug.Log("_icon != null && _icon.sprite != null");
            }
        }

    }
}
