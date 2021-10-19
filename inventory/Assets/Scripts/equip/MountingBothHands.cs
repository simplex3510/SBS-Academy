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
            // 양쪽 손 체크
            // Button_inven leftBtn = 

            if (_targetEquipSlot.m_button_Inven.m_invenDataRec != null) // 착용 장비 있다면
            {
                _targetEquipSlot.m_button_Inven.m_invenDataRec.m_equipSlotID = E_equipSlotID.none;
                _targetEquipSlot.set_Equipment(_sorRec);
            }
            else
            {
                _targetEquipSlot.set_Equipment(_sorRec);
            }
        }
    }
}
