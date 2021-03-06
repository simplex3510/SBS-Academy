using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum E_equipSlotID
{
    none = 0,
    leftHand,
    rightHand,
    head,
    shoulder,
    bust,
    bottoms,
    shoes,
    necklace1,
    necklace2,
    ring1,
    ring2,
    belt,
    lockMounting
}

[System.Serializable]
public class EquipSlotInfo : MonoBehaviour
{
    public E_equipSlotID m_slotID;
    // public InvenDataRec m_invenDataRec;
    public Button_inven m_button_Inven;

    E_equipSlotID m_startSlotID;

    private void Start()
    {
        m_startSlotID = m_slotID;
    }
    public void set_StartSlotID()  // lock로 바뀐 경우 호출 필요.
    {
        m_slotID = m_startSlotID;
    }

    public void set_Equipment(InvenDataRec _rec)
    {
        _rec.m_equipSlotID = m_slotID;
        m_button_Inven.m_invenDataRec = _rec;
        //m_button_Inven.m_invenDataRec.m_equipSlotID = m_slotID;

        //m_invenDataRec = _rec;
        //m_invenDataRec.m_equipSlotID = m_slotID;
    }
}

