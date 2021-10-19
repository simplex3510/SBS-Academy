using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenData : MonoBehaviour
{
    [SerializeField]
    private InvenDataList m_invenDataList;

    public bool Set_Mounting(InvenDataRec _rec, EquipSlotInfo _targetEquipSlot)
    {
        return m_invenDataList.Set_Mounting(_rec, _targetEquipSlot);
    }
    public void Set_dismount(InvenDataRec _rec)
    {
        m_invenDataList.Set_dismount(_rec);
    }

    public InvenDataRec Get_data(E_equipSlotID _equipSlot)
    {
        for(int ix =0; ix<m_invenDataList.m_dataList.Count; ix++)
        {
            if(m_invenDataList.m_dataList[ix].m_equipSlotID == _equipSlot)
            {
                return m_invenDataList.m_dataList[ix];
            }
        }
        return null;
    }

    public InvenDataRec Get_data(int ix)
    {
        if(ix < 0 || ix >= m_invenDataList.m_dataList.Count)
        {
            Debug.Log("InvenDataRec Get_data null" + ix);
            return null;
        }
        return m_invenDataList.m_dataList[ix];
    }

    //==================== data 추가 및 저장 관리
    
    public void SaveData(List<Button_inven> _list)
    {
        m_invenDataList.m_dataList.Clear();
        for(int ix = 0; ix<_list.Count; ix++)
        {
            Debug.Log(" _list[ix].invenDataRec :" + ix + " " + _list[ix].m_invenDataRec);
            m_invenDataList.m_dataList.Add(_list[ix].m_invenDataRec);
        }
        SaveData();
    }

    public void Add(InvenDataRec _rec)
    {
        m_invenDataList.m_dataList.Add(_rec);
        SaveData();
    }
    public void SaveData()
    {
        m_invenDataList.Set_dataIndex();
        string jsonString = JsonUtility.ToJson(m_invenDataList);
        PlayerPrefs.SetString("InvenData", jsonString);
    }
    public void LoadDefault()
    {
        m_invenDataList.m_dataList.Clear();

        InvenDataRec tmp = new InvenDataRec();
        tmp.m_invenIndex = 0;
        tmp.m_itemID = "sword";
        tmp.m_count = 1;
        tmp.m_equipSlotID = E_equipSlotID.none;
        m_invenDataList.m_dataList.Add(tmp);
    }
    public void LoadData()
    {
        m_invenDataList.m_dataList.Clear();

        if (PlayerPrefs.HasKey("InvenData") == false)
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

