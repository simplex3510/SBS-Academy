using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InvenDataRec
{
    public int m_invenIndex;
    public string m_itemID;
    public int m_count;
    public E_equipSlotID m_EquipSlotID;
}

[System.Serializable]
public class InvenDataList
{
    public const float C_mountingFlag = 0.01f;

    public enum E_mountingType
    {
        None = 0,
        oneHand,
        bothHand,
        head,
        shoulder,
        bust,
        fullAmor,
        bottoms,
        shoes,
        necklace,
        ring,
        belt,
        end     //
    }

    public List<InvenDataRec> m_dataList;
    public MountingBase m_mountingBase;
    public MountingOneHand m_mountingOneHand = new MountingOneHand();
    public MountingBothHand m_mountingBothHand = new MountingBothHand();
    public MountingHead m_mountingHead = new MountingHead();

    public void Set_dataIndex()
    {
        for(int ix=0; ix < m_dataList.Count; ix++)
        {
            if(m_dataList[ix] == null)
            {
                m_dataList[ix] = new InvenDataRec();
            }
            m_dataList[ix].m_invenIndex = ix;
        }
    }

    int Get_actionTypeToE_mountingType_int(ItemInfoRec _item)
    {
        return (Mathf.FloorToInt(_item.m_actionType * C_mountingFlag) % 100);
    }

    public bool CheckMounting(ItemInfoRec _item, EquipSlotInfo _equipSlotInfo)
    {
        if(_equipSlotInfo == null)
        {
            return false;
        }
        if(_equipSlotInfo.m_slotID == E_equipSlotID.lockMounting)
        {
            return false;
        }

        int checkVal = Get_actionTypeToE_mountingType_int(_item);

        E_mountingType mountingType = (E_mountingType)checkVal;
        Debug.Log(mountingType);

        if(mountingType == E_mountingType.None || checkVal >= (int)E_mountingType.end)
        {
            return false;
        }
        return true;
    }

    public bool Set_Mounting(InvenDataRec _rec, EquipSlotInfo _targetEquipSlot)
    {
        ItemInfoRec item = ItemMgr.instance.Get_Data(_rec.m_itemID);
        if(CheckMounting(item, _targetEquipSlot) == false)
        {
            return false;
        }
        int checkVal = Get_actionTypeToE_mountingType_int(item);
        E_mountingType mountingType = (E_mountingType)checkVal;

        switch(mountingType)
        {
            case E_mountingType.oneHand:
                m_mountingBase = m_mountingOneHand;
                break;
            case E_mountingType.bothHand:
                m_mountingBase = m_mountingBothHand;
                break;
            default:
                Debug.Log("");
                break;
        }
        m_mountingBase.set_mounting(_rec, _targetEquipSlot);

        return true;
    }

    public void Set_dismount(InvenDataRec _rec)
    {
        ItemInfoRec item = ItemMgr.instance.Get_Data(_rec.m_itemID);
        int checkVal = Get_actionTypeToE_mountingType_int(item);
        E_mountingType mountingType = (E_mountingType)checkVal;

        switch (mountingType)
        {
            case E_mountingType.oneHand:
                m_mountingBase = m_mountingOneHand;
                break;
            case E_mountingType.bothHand:
                m_mountingBase = m_mountingBothHand;
                break;
            default:
                Debug.Log("E_mountingType default case...");
                break;
        }
        m_mountingBase.set_mounting(_rec);
    }
}
