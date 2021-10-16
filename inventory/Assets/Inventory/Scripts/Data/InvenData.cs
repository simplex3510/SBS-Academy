using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ItemID_Count
{
    public string m_itemID;
    public int m_count;
}

[System.Serializable]
public class InvenDataList
{
    public List<ItemID_Count> m_dataList = new List<ItemID_Count>();
}

public class InvenData : MonoBehaviour
{
    public InvenDataList m_invenDataList = new InvenDataList();

    public void SaveData()
    {
        string jsonString = JsonUtility.ToJson(m_invenDataList);
        PlayerPrefs.SetString("InvenData", jsonString);
    }

    public void LoadDefault()
    {
        ItemID_Count tmp;
        tmp.m_itemID = "sword";
        tmp.m_count = 1;
        m_invenDataList.m_dataList.Add(tmp);
    }

    public void LoadData()
    {
        m_invenDataList.m_dataList.Clear();

        if(PlayerPrefs.HasKey("InvenData") == false)
        {
            LoadDefault();
            return;
        }

        string jsonString = PlayerPrefs.GetString("InvenData");
        m_invenDataList = JsonUtility.FromJson<InvenDataList>(jsonString);
    }

    public void DeleteKey()
    {
        PlayerPrefs.DeleteKey("InvenData");
    }
}
