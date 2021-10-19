using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_inven: Button_item
{
    public InvenDataRec m_invenDataRec;

    public void set_Data(InvenDataRec _invenDataRec, ItemInfoRec _item )
    {
        base.set_Data(_item);
        m_invenDataRec = _invenDataRec;
    }
    public override void Click_item()
    {
        UIMgr.instance.m_panel_Inventory.DisplayPopupMsg();
    }

    public override void Set_sprite()
    {
        base.Set_sprite();
        Debug.Log(" invenDataRec -- set ÇÊ¿ä. ");
    }
    public void Set_invenDataRec(InvenDataRec _rec)
    {
        base.Set_sprite();
        m_invenDataRec = _rec;

    }
}
