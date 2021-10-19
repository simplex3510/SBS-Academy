using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountingBase 
{
    
    public virtual void set_mounting(InvenDataRec _sorRec, EquipSlotInfo _targetEquipSlot)
    {

    }
    public virtual void set_dismount(InvenDataRec _sorRec)
    {
        _sorRec.m_equipSlotID = E_equipSlotID.none;
    }
}
