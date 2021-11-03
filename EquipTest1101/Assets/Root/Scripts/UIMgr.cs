using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

public class UIMgr : MonoBehaviour
{
    #region singleton
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
                    Debug.LogError(" _instance null");
                    return null;
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError(" UIMgr duplicated.  ");
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public Canvas m_canvas;



}
