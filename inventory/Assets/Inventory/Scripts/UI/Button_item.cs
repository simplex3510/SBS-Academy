using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_item : MonoBehaviour
{
    public ItemInfoRec m_info;
    public Image m_iconSprite;

    public virtual void Click_item()
    {
        UIMgr.instance.m_panel_ItemBook.DisplayItem(m_info.m_itemID);
    }

    public virtual void Set_sprite()
    {
        if (m_info.m_itemID.Trim() == "")
        {
            m_iconSprite.sprite = IconMgr.instance.Get_sprtie("none");
            return;
        }
        m_iconSprite.sprite = IconMgr.instance.Get_sprtie(m_info.m_iconName);
    }
}
