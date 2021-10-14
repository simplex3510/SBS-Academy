using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemInfoRec
{
    public string m_itemID;
    public string m_iconName;
    public string m_itemName;
    public string m_desc;
    public int m_actionType;
}

[System.Serializable]
public class ItemInfoTable
{
    public List<ItemInfoRec> m_dataList;
}
