using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_item : MonoBehaviour
{
    public ItemInfoRec m_info = null;
    public Image m_iconSprite;

    protected void set_Data(ItemInfoRec _info)
    {
        m_info = _info;
        Set_sprite();
    }

    public virtual void Click_item()
    {
        UIMgr.instance.m_panel_ItemBook.DisplayItem(m_info.m_itemID);
    }

    public virtual void Set_sprite()
    {
        if(m_info == null || string.IsNullOrEmpty(m_info.m_itemID) ) // m_info.m_itemID.Trim() == "")
        {
            m_iconSprite.sprite = IconMgr.instance.Get_sprite("none");
            return;
        }
        m_iconSprite.sprite = IconMgr.instance.Get_sprite(m_info.m_iconName);
    }
}
