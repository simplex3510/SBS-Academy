using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iconMgrTest : MonoBehaviour
{
    public string m_iconID;
    public Image m_image;
    
    public void Click_Test()
    {
        m_image.sprite = IconMgr.instance.Get_sprite(m_iconID);
    }
}
