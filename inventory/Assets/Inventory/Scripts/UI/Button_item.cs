using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_item : MonoBehaviour
{
    public ItemInfoRec m_info;
    public Image m_iconSprite;

    public void Click_item()
    {
        UIMgr.instance.m_panel_ItemBook.DisplayItem(m_info.m_itemID);
    }

    public void Set_sprite()
    {
        m_iconSprite.sprite = IconMgr.instance.Get_sprtie(m_info.m_iconName);
    }
}
