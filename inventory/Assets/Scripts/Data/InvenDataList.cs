using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InvenDataRec
{
    public int m_invenIndex;
    public string m_itemID;
    public int m_count;
    public E_equipSlotID m_equipSlotID;
}

[System.Serializable]
public class InvenDataList
{
    public const float C_mountingFlag = 0.01f;
    // x00xx 착용장비아님, 100 한손 착용 장비, 200 양손 착용,
    // 300 머리 착용, 400 어께 착용, 500 상반신, 600 상하일체형, 700바지, 800신발,
    // 900목걸이, 1000반지, 11허리띠, 12착용 잠김( 조건에 따라 속성 변경됨).
    public enum E_mountingType
    {
        None = 0,
        OneHand,
        bothHands,
        head,
        shoulder,
        bust,
        fullArmor,
        bottoms,
        shoes,
        necklace,
        ring,
        belt,
        end  // 추가시 end 위에추가.
    }
    
    public List<InvenDataRec> m_dataList;
    public MountingBase m_mountingBase;
    public MountingOneHand m_mountingOneHand = new MountingOneHand();
    public MountingBothHands m_mountingBothHands = new MountingBothHands();
    public MountingHead m_mountingHead = new MountingHead();


    public void Set_dataIndex()
    {
        for(int ix = 0; ix<m_dataList.Count; ix++)
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
        return (Mathf.FloorToInt(_item.m_actionType * C_mountingFlag) % 100); //m_actionType 을 E_mountingType int로 필터링.
    }
    public bool CheckMounting(ItemInfoRec _item, EquipSlotInfo _equipSlotInfo)
    {
        if (_equipSlotInfo == null)
            return false;
        if (_equipSlotInfo.m_slotID == E_equipSlotID.lockMounting) // 양손 장비, 풀아머 등으로 한쪽 슬롯 잠김.
            return false;

        int checkVal = Get_actionTypeToE_mountingType_int(_item);//m_actionType 을 E_mountingType int로 필터링.
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
        if (CheckMounting(item, _targetEquipSlot) == false)
        {
            return false;
        }
        int checkVal = Get_actionTypeToE_mountingType_int(item);
        E_mountingType mountingType = (E_mountingType)checkVal;

        // 착용 하려는 _rec 가 어떤 타입인가? 
        switch (mountingType)
        {
            case E_mountingType.OneHand:
                m_mountingBase = m_mountingOneHand;
                break;
            case E_mountingType.bothHands:
                m_mountingBase = m_mountingBothHands;
                break;
            default:
                Debug.Log(" E_mountingType default case ...");
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

        //  _rec 가 어떤 타입인가? 
        switch (mountingType)
        {
            case E_mountingType.OneHand:
                m_mountingBase = m_mountingOneHand;
                break;
            case E_mountingType.bothHands:
                m_mountingBase = m_mountingBothHands;
                break;
            default:
                Debug.Log(" E_mountingType default case ...");
                break;
        }

        m_mountingBase.set_dismount(_rec);

        return;
    }
}


