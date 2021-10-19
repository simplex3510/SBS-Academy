using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum E_moveGroup
{
	none,
	invenItem,
	hands,
	ring,
	necklace
}

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
	public Button_inven m_itemObj;
	public EquipSlotInfo m_equipSlotInfo;
	public E_moveGroup m_moveGroup = E_moveGroup.none;
	public void OnDrop(PointerEventData eventData)
	{
		var item = ItemDragHandler.m_itemBeingDragged;
		Debug.Log("OnDrop item ");
		if (item != null ) // && !string.IsNullOrEmpty(item.m_info.m_itemID) )
		{
			ItemDropHandler sorDrop = item.GetComponent<ItemDropHandler>();
			if (sorDrop == null)
			{
				Debug.Log("sorDrop == null");
				return;
			}
			// Debug.Log("sorDrop.m_equipSlotInfo : " + sorDrop.m_equipSlotInfo);
			
			if ( m_moveGroup != E_moveGroup.none && sorDrop.m_moveGroup == m_moveGroup
				)
			{
				// 데이터 바꾸기 전 left, right 확인 교환
				if (m_equipSlotInfo != null)
				{
					if (m_equipSlotInfo.m_button_Inven.m_invenDataRec != null
						&& (m_equipSlotInfo.m_slotID == E_equipSlotID.leftHand
							|| m_equipSlotInfo.m_slotID == E_equipSlotID.rightHand
							)
						)
					{
						E_equipSlotID tmp = item.m_invenDataRec.m_equipSlotID;
						item.m_invenDataRec.m_equipSlotID = m_equipSlotInfo.m_slotID;
						m_equipSlotInfo.m_button_Inven.m_invenDataRec.m_equipSlotID = tmp;
					}
				}
				ItemInfoRec tmpItem = m_itemObj.m_info;  // 데이터 바꾸기.
				InvenDataRec tmpInven = m_itemObj.m_invenDataRec;
				m_itemObj.set_Data(item.m_invenDataRec, item.m_info);
				item.set_Data(tmpInven, tmpItem);
				
            }
            else if(m_equipSlotInfo != null && sorDrop.m_equipSlotInfo == null) // 장비
            {
				Player p = GameMgr.instance.Get_player();
				bool b = p.m_invenData.Set_Mounting(item.m_invenDataRec, m_equipSlotInfo);
				if (b == false)
				{
					Debug.Log("CheckMounting : false");
					return;
				}
				UIMgr.instance.m_panel_Inventory.Display_PlayerInvenToSlotList();
			}else if (sorDrop.m_equipSlotInfo != null && m_equipSlotInfo == null) // 해제
            {
				Debug.Log("해제");
				Player p = GameMgr.instance.Get_player();
				p.m_invenData.Set_dismount(item.m_invenDataRec);
				//		item.m_invenDataRec.m_equipSlotID = E_equipSlotID.none;
				
				UIMgr.instance.m_panel_Inventory.Display_PlayerInvenToSlotList();
            }
            else
            {
				Debug.Log("해제 오류: [" + sorDrop.m_equipSlotInfo + "] , [" + m_equipSlotInfo + "] ");
			}
			UIMgr.instance.m_panel_Inventory.SaveInvenListToPlayerData();


		}
	}

}