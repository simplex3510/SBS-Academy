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
    // x00xx �������ƴ�, 100 �Ѽ� ���� ���, 200 ��� ����,
    // 300 �Ӹ� ����, 400 � ����, 500 ��ݽ�, 600 ������ü��, 700����, 800�Ź�,
    // 900�����, 1000����, 11�㸮��, 12���� ���( ���ǿ� ���� �Ӽ� �����).
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
        end  // �߰��� end �����߰�.
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
        return (Mathf.FloorToInt(_item.m_actionType * C_mountingFlag) % 100); //m_actionType �� E_mountingType int�� ���͸�.
    }
    public bool CheckMounting(ItemInfoRec _item, EquipSlotInfo _equipSlotInfo)
    {
        if (_equipSlotInfo == null)
            return false;
        if (_equipSlotInfo.m_slotID == E_equipSlotID.lockMounting) // ��� ���, Ǯ�Ƹ� ������ ���� ���� ���.
            return false;

        int checkVal = Get_actionTypeToE_mountingType_int(_item);//m_actionType �� E_mountingType int�� ���͸�.
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

        // ���� �Ϸ��� _rec �� � Ÿ���ΰ�? 
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

        //  _rec �� � Ÿ���ΰ�? 
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


