using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountingBothHands : MountingBase
{
    
    public override void set_mounting(InvenDataRec _sorRec, EquipSlotInfo _targetEquipSlot)
    {
        Debug.Log(" E_mountingType bothHands case ...");
        if (_targetEquipSlot.m_slotID == E_equipSlotID.leftHand
            || _targetEquipSlot.m_slotID == E_equipSlotID.rightHand)
        {
            // 양쪽 손 체크 후 장비 중인 것은 none로 만든다.
            InvenData data = GameMgr.instance.Get_player().m_invenData;
            InvenDataRec leftData = data.Get_data(E_equipSlotID.leftHand);
            if(leftData != null)
            {
                leftData.m_equipSlotID = E_equipSlotID.none;
            }
            InvenDataRec rightData = data.Get_data(E_equipSlotID.rightHand);
            if(rightData != null)
            {
                rightData.m_equipSlotID = E_equipSlotID.none;
            }

            // 왼손에 장비 장착, 오른손 lock 처리
            _sorRec.m_equipSlotID = E_equipSlotID.leftHand;
            Debug.Log("==========================================     ");
            _targetEquipSlot.set_Equipment(_sorRec);

            //// Button_inven leftBtn = 
            //if (_targetEquipSlot.m_button_Inven.m_invenDataRec != null) // 착용 장비 있다면
            //{
            //    _targetEquipSlot.m_button_Inven.m_invenDataRec.m_equipSlotID = E_equipSlotID.none;
            //    _targetEquipSlot.set_Equipment(_sorRec);
            //}
            //else
            //{
            //    _targetEquipSlot.set_Equipment(_sorRec);
            //}
        }
    }
}
