using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel_ItemBook : MonoBehaviour
{
    public Text m_itemName;
    public Text m_itemDesc;

    private void Start()
    {
        m_itemName.text = "";
        m_itemDesc.text = "";
    }

    public void DisplayItem(string id)
    {
        m_itemName.text = ItemMgr.instance.Get_itemName(id);
        m_itemDesc.text = ItemMgr.instance.Get_itemDesc(id);
    }
}
