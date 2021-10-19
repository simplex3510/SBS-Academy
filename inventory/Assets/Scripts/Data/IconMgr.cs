using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconMgr : MonoBehaviour
{
    #region singleton
    // public static IconMgr instance { get; private set; }
    private static IconMgr _instance = null;
    public static IconMgr instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(IconMgr)) as IconMgr;
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
            Debug.LogError(" IconDictionary duplicated.  ");
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    [Header("== 아이콘 리스트 ==")]
    public List<Sprite> m_lstSprite;
    [System.Serializable]
    public class SerializeDicStringSprite : CustomDic.SerializableDictionary<string, Sprite> { }
    public SerializeDicStringSprite m_dicIcon;


    public void Setup_DictSprite()
    {
        m_dicIcon.Clear();
        foreach (var spr in m_lstSprite)
        {
            m_dicIcon.Add(spr.name, spr);
        }
        Debug.Log(" m_dicIcon count: " + m_dicIcon.Count);
    }

    public Sprite Get_sprite(string strkey)
    {
        if (m_dicIcon.ContainsKey(strkey))
            return m_dicIcon[strkey];
        else
            return null;
    }
    
}
