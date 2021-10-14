using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    private static UIMgr _instance = null;
    public static UIMgr instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(UIMgr)) as UIMgr;
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
            Debug.LogError("UIMgr duplicated");
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Canvas m_canvas;
    
    public Panel_ItemBook m_panel_ItemBook;
}
