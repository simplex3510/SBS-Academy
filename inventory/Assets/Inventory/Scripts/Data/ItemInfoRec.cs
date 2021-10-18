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

    public float m_value1;  // 액션 타입 적용 값1
    public float m_value2;  // 액션 타입 적용 값2
}

[System.Serializable]
public class ItemInfoTable
{
    public List<ItemInfoRec> m_dataList;
}
