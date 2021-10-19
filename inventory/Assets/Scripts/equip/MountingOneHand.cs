using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountingOneHand : MountingBase
{
    public override void set_mounting(InvenDataRec _sorRec, EquipSlotInfo _targetEquipSlot)
    {
        Debug.Log(" E_mountingType OneHand case ...");
        if (_targetEquipSlot.m_slotID == E_equipSlotID.leftHand
            || _targetEquipSlot.m_slotID == E_equipSlotID.rightHand)
        {
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
