using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfoRec
{
    public string m_itemID;
    public string m_iconName;
    public string m_itemName;
    public string m_desc;
    public int m_actionType;

    public float m_value1;  // �׼� Ÿ�� ���� ��1
    public float m_value2;  // �׼� Ÿ�� ���� ��2
}

[System.Serializable]
public class ItemInfoTable
{
    public List<ItemInfoRec> m_dataList;
}
