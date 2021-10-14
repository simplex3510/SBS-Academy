using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMgr : MonoBehaviour
{
    #region singletone
    private static ItemMgr _instance = null;
    public static ItemMgr instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(ItemMgr)) as ItemMgr;
                if (!_instance)
                {
                    Debug.LogError("_instance null");
                    return null;
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("ItemMgr duplicated");
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [Header("==테이블 데이터==")]
    public ItemInfoTable m_infoTable;
    public TextAsset m_jsonInfoFile;

    public Transform m_root_itemBookContent;
    public GameObject m_Button_item;

    public void Setup_itemBookContent()
    {
        foreach (var item in m_infoTable.m_dataList)
        {
            GameObject obj = Instantiate(m_Button_item);
            obj.transform.SetParent(m_root_itemBookContent);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            obj.GetComponent<Button_item>().m_info = item;
            obj.GetComponent<Button_item>().Set_sprite();
        }
    }

    public string Get_itemName(string id)
    {
        foreach(var item in m_infoTable.m_dataList)
        {
            if(item.m_itemID == id)
            {
                return item.m_iconName;
            }
        }
        return null;
    }

    public string Get_itemDesc(string id)
    {
        foreach (var item in m_infoTable.m_dataList)
        {
            if (item.m_itemID == id)
            {
                return item.m_desc;
            }
        }
        return null;
    }
}
