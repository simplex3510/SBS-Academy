using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotRightHand : SlotHand
{    
    public SlotLeftHand m_another;
    
    public override void OnDrop(Image _img, WeaponData _data)
    {
        if(GameMgr.instance.Get_player().Equip_R_currData() == true)
        {
            m_icon.sprite = _img.sprite;
            m_currData = _data;
            if (_data.m_isBothHands == true)
            {
                m_another.m_icon.sprite = null;
                m_another.m_currData = null;
            }
            else if(m_another != null && m_another.m_currData != null && m_another.m_currData.m_isBothHands == true)
            {
                m_another.m_icon.sprite = null;
                m_another.m_currData = null;
            }
        }
    }
    public void Click_Unequip()
    {
        m_icon.sprite = null;
        m_currData = null;
        GameMgr.instance.Get_player().Click_RightUnequip();
    }
}
