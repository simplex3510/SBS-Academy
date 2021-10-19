using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Inventory : MonoBehaviour
{
    public List<Button_inven> m_lstBtn_item;
    public List<Button_inven> m_lstBtn_eqpSlot;
    public GameObject m_popupMsg;

    public bool m_isFirstOpen = false;

    public void SaveInvenListToPlayerData()
    {
        if(GameMgr.instance)
            GameMgr.instance.Get_player().m_invenData.SaveData(m_lstBtn_item);
    }

    public void DisplayPopupMsg()
    {
        m_popupMsg.SetActive(true);
    }

    public void set_PlayerInvenToItemList()
    {
        InvenData data = GameMgr.instance.Get_player().m_invenData;
        for (int ix =0; ix< m_lstBtn_item.Count; ix++)
        {
            InvenDataRec invenRec = data.Get_data(ix);
            Debug.Log(" data.Get_data(ix) " + ix + " invenRec: " + invenRec);
            if(invenRec == null)
            {
                Debug.Log("invenRec == null " + ix);
                m_lstBtn_item[ix].m_info = null;
                m_lstBtn_item[ix].Set_invenDataRec(null);
                continue;
            }
            ItemInfoRec rec = ItemMgr.instance.Get_Data(invenRec.m_itemID);
            
            m_lstBtn_item[ix].m_info = rec;
            m_lstBtn_item[ix].Set_invenDataRec(invenRec);
        }
    }

    public void Display_PlayerInvenToSlotList()
    {
        InvenData data = GameMgr.instance.Get_player().m_invenData;
        for (int ix = 0; ix < m_lstBtn_eqpSlot.Count; ix++)
        {
            EquipSlotInfo slotInfo = m_lstBtn_eqpSlot[ix].GetComponent<EquipSlotInfo>();
            InvenDataRec sor = data.Get_data(slotInfo.m_slotID);
            if(sor != null)
            {
                m_lstBtn_eqpSlot[ix].set_Data(sor, ItemMgr.instance.Get_Data(sor.m_itemID));
            }
            else
            {
                m_lstBtn_eqpSlot[ix].set_Data(null, null);
                m_lstBtn_eqpSlot[ix].Set_sprite();
            }
        }
    }
    public Button_inven get_button_inven(E_equipSlotID _slot)
    {
        for (int ix = 0; ix < m_lstBtn_eqpSlot.Count; ix++)
        {
            EquipSlotInfo slotInfo = m_lstBtn_eqpSlot[ix].GetComponent<EquipSlotInfo>();
            
            if (slotInfo.m_slotID == _slot)
            {
                return m_lstBtn_eqpSlot[ix];
            }
        }
        return null;
    }
    //public void Display_PlayerInven()
    //{
    //    for (int ix = 0; ix < m_lstBtn_item.Count; ix++)
    //    {
    //        ItemInfoRec rec = m_lstBtn_item[ix].m_info;
    //        m_lstBtn_item[ix].m_info = rec;
    //        m_lstBtn_item[ix].Set_sprite();
    //    }
    //}
    void ClearItemUI()
    {
        foreach (var btn_item in m_lstBtn_item)
        {
            btn_item.m_info = null; // .m_itemID = "";
            btn_item.Set_invenDataRec(null);
        }
    }
    public void OnEnable()
    {
        ClearItemUI();
        set_PlayerInvenToItemList();

        Display_PlayerInvenToSlotList();
        
    }
    
}
