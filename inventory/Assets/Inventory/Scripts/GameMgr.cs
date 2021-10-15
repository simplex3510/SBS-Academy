using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private static GameMgr _instance = null;
    public static GameMgr instacne
    {
        get
        {
            if(!_instance)
            {
                _instance = GameObject.FindObjectOfType(typeof(GameMgr)) as GameMgr;
                if(!_instance)
                {
                    Debug.Log("_instance Null");
                    return null;
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance != null && _instance != true)
        {
            Debug.LogError("GameMgr duplicated");
        }
    }
}
