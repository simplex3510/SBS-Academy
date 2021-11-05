using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_L : SlotHand
{
    public Slot_R m_slot_R;

    public void Click_Unequip()
    {
        GameMgr.instance.Get_player().Click_leftUnequip();

        base.Unequip();
    }

    public override void OnDrop(Image _icon )
    {
        Player p = GameMgr.instance.Get_player();
        if ( p.Equip_L_currentDragData() == true )
        {
            if (_icon != null && _icon.sprite != null)
            {
                // ��� ���� UIó��.
                m_icon.sprite = _icon.sprite;
                m_equipWeaponData = GameMgr.instance.m_currentDragData;
                //=========================

                // ������ ��� �Ǵ� ó��. 
                if(m_slot_R.m_equipWeaponData != null 
                    && m_slot_R.m_equipWeaponData.m_isbothHands == true
                    )
                {
                    // ��� ���� UI ó��.
                    m_slot_R.Unequip();
                }
            }
            else
            {
                Debug.Log("_icon != null && _icon.sprite != null");
            }
        }
    }

}
