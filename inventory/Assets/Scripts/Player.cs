using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InvenData m_invenData;
    public Transform m_equip_R;
    public GameObject m_prefab2HandSword;
    public GameObject m_currentWeapon;


    private void Start()
    {
        m_invenData.LoadData();
    }

    public void Click_equip2HandSword()
    {

        m_currentWeapon = Instantiate(m_prefab2HandSword);
        m_currentWeapon.transform.parent = m_equip_R;
        m_currentWeapon.transform.localPosition = Vector3.zero;
        m_currentWeapon.transform.localRotation = Quaternion.identity;
        m_currentWeapon.transform.localScale = Vector3.one;
    }

    public void OnMove(Vector3 _pos, Quaternion _rot)
    {
        Debug.Log(" Delta pos:" + _pos + ", _rot:" + _rot);
    }
}
