using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Inventory : MonoBehaviour
{
    public List<Button_inven> m_lstBtn_item;
    public GameObject m_popupMsg;

    public void DisplayPopupMsg()
    {
        m_popupMsg.SetActive(true);
    }

    public void Display_PlayerInven()
    {
        InvenData data = GameMgr.instance.Get_player().m_invenData;

        for (int ix = 0; ix < data.m_invenDataList.m_dataList.Count; ix++)
        {
            string id = data.m_invenDataList.m_dataList[ix].m_itemID;
            Debug.Log(id);
            ItemInfoRec rec = ItemMgr.instance.Get_Data(id);

            if(string.IsNullOrEmpty(rec.m_itemID))
            {
                Debug.Log("InvenData IsNullOrEmpty: " + id);
                return;
            }
            m_lstBtn_item[ix].m_info = rec;
            m_lstBtn_item[ix].Set_sprite();
        }
    }

    void ClearItemUI()
    {
        foreach(var btn_item in m_lstBtn_item)
        {
            btn_item.m_info.m_itemID = "";
            btn_item.Set_sprite();
        }
    }

    public void OnEnable()
    {
        ClearItemUI();

        Display_PlayerInven();
    }
}
