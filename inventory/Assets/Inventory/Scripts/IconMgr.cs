using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMgr : MonoBehaviour
{
    private static IconMgr _instance = null;

    #region singletone
    public static IconMgr instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(IconMgr)) as IconMgr;
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
            Debug.LogError("IconMgr duplicated");
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public Canvas m_canvas;

    [Header("==아이콘 리스트==")]
    public List<Sprite> m_lstSprite;
    [System.Serializable]
    public class SerializeDicStringSprite : CustomDic.SerializableDictionary<string, Sprite> { };
    public SerializeDicStringSprite m_dicIcon;

    public void Setup_DicSprite()
    {
        m_dicIcon.Clear();
        foreach (var spr in m_lstSprite)
        {
            m_dicIcon.Add(spr.name, spr);
        }
        Debug.Log("m_dicIcon count: " + m_dicIcon.Count);
    }

    public Sprite Get_sprtie(string strkey)
    {
        if (m_dicIcon.ContainsKey(strkey))
        {
            return m_dicIcon[strkey];
        }
        else
        {
            return null;
        }
    }
}
