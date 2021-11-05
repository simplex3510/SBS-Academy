using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [System.Serializable]
    public struct ProjectileData
    {
        public List<Projectile> m_lstPlayerSwing;
    }


    #region singleton
    public static ProjectileManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    public List<Projectile> m_lstPlayerSwing01 = new List<Projectile>();

    public List<ProjectileData> m_projDataWarrior;
    // class, skill start index = 1000;
    // 0 : �� ����,
    // 1 : �ٿ� ����,
    // 2 : �ٿ� ����,
    // 3 : spec 1��

    //[SerializeField]
    //public Dictionary<int, ProjectileData> m_projDataEnemy;
    [System.Serializable]
    public class SerializeDicEntity : CustomDic.SerializableDictionary<int, ProjectileData> { } // Ŭ������ �����.
    public SerializeDicEntity m_projDataEnemy;


    public GameObject Spawn_projDataWarrior(Transform _pos, int _index)
    {
        List<Projectile> lstTmp = m_projDataWarrior[_index].m_lstPlayerSwing;

        foreach (Projectile tmp in lstTmp)
        {
            if (tmp.gameObject.activeSelf == false)
            {
                tmp.Spawn(_pos);
                return tmp.gameObject;
            }
        }
        return null;
    }


    public GameObject Spawn_playerSwing01(Transform _pos)
    {
        Debug.Log(" Spawn_playerSwing01 _pos:" + _pos);

        // for (int ix = 0; ix < m_lstPlayerSwing01.Count; ix++)
        // { Projectile tmp = m_lstPlayerSwing01[ix];  .... } 
        foreach (Projectile tmp in m_lstPlayerSwing01)
        {
            if(tmp.gameObject.activeSelf == false)
            {
                tmp.Spawn(_pos);
                return tmp.gameObject;
            }
        }
        return null;
    }
    public GameObject Spawn_projDataEnemySkill(Transform _pos, int _index)
    {
        List<Projectile> lstTmp = m_projDataEnemy[_index].m_lstPlayerSwing;

        foreach (Projectile tmp in lstTmp)
        {
            if (tmp.gameObject.activeSelf == false)
            {
                tmp.Spawn(_pos);
                return tmp.gameObject;
            }
        }
        return null;
    }

}
