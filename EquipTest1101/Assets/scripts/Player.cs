using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_obj2HandSword;
    public GameObject m_objSwordR;
    public GameObject m_objSwordL;
    public GameObject m_objCurrent_R;
    public GameObject m_objCurrent_L;
    public Animator m_animator;

    public WeaponData m_dragData;

    public bool Equip_L_currData()
    {
        if(m_dragData == null )
        {
            return false;
        }
        if(m_dragData.m_weaponName == "2HandSword")
        {
            // Click_2HandSword();
            return false;
        }else if(m_dragData.m_weaponName ==  "Sword")
        {
            Click_Sword_L();
            return true;
        }
        return false;
    }
    public bool Equip_R_currData()
    {
        if (m_dragData == null)
        {
            return false;
        }
        if (m_dragData.m_weaponName == "2HandSword")
        {
            Click_2HandSword();
            return true;
        }
        else if (m_dragData.m_weaponName == "Sword")
        {
            Click_Sword_R();
            return true;
        }
        return false;
    }

    public void Click_LeftUnequip()
    {
        if (m_objCurrent_L)
        {
            m_objCurrent_L.SetActive(false);
        }
        m_objCurrent_L = null;

        if (m_objCurrent_R == null && m_objCurrent_L == null)
            Click_unarmed();
    }
    public void Click_RightUnequip()
    {
        if (m_objCurrent_R)
        {
            m_objCurrent_R.SetActive(false);
        }
        m_objCurrent_R = null;

        if (m_objCurrent_R == null && m_objCurrent_L == null)
            Click_unarmed();
    }

    public void Click_unarmed()
    {
        if(m_objCurrent_R)
        {
            m_objCurrent_R.SetActive(false);
        }
        if (m_objCurrent_L)
        {
            m_objCurrent_L.SetActive(false);
        }
        m_objCurrent_R = m_objCurrent_L = null;

        m_animator.SetTrigger("Equip");
        m_animator.SetInteger("Weapon", 0); // enum 설정 필요.
    }
    public void Click_2HandSword()
    {
        if (m_objCurrent_R)
        {
            m_objCurrent_R.SetActive(false);
        }
        if (m_objCurrent_L)
        {
            m_objCurrent_L.SetActive(false);
        }
        m_objCurrent_R = m_obj2HandSword;
        m_objCurrent_L = null;

        m_animator.SetTrigger("Equip");
        m_animator.SetInteger("Weapon", 1); // enum 설정 필요.
    }
    public void Click_Sword_R()
    {
        if (m_objCurrent_R)
        {
            m_objCurrent_R.SetActive(false);
        }
        if (m_objCurrent_L)
        {
            if(!m_objCurrent_L.CompareTag("DualType"))
            {
                m_objCurrent_L.SetActive(false);
                m_objCurrent_L = null;
            }
        }
        m_objCurrent_R = m_objSwordR;

        m_animator.SetTrigger("Equip");
        m_animator.SetInteger("Weapon", 3); // enum 설정 필요.
    }
    public void Click_Sword_L()
    {
        if (m_objCurrent_L)
        {
            m_objCurrent_L.SetActive(false);
        }
        if (m_objCurrent_R)
        {
            if (!m_objCurrent_R.CompareTag("DualType"))
            {
                m_objCurrent_R.SetActive(false);
                m_objCurrent_R = null;
            }
        }
        
        m_objCurrent_L = m_objSwordL;

        m_animator.SetTrigger("Equip");
        m_animator.SetInteger("Weapon", 2); // enum 설정 필요.
    }


    public void ev_WeaponSwitch()
    {
        Debug.Log(" WeaponSwitch()  !!!");
        if(m_objCurrent_R && m_objCurrent_R.activeSelf == false)
        {
            m_objCurrent_R.SetActive(true);
        }
        if (m_objCurrent_L && m_objCurrent_L.activeSelf == false)
        {
            m_objCurrent_L.SetActive(true);
        }
    }

    public void DropItem_LeftSlot(GameObject _obj)
    {

    }
    public void DropItem_RightSlot(GameObject _obj)
    {

    }
}
