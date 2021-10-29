using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_obj2HandSword;
    public GameObject m_objCurrent;
    public Animator m_animator;

    public void Click_unarmed()
    {
        if(m_objCurrent)
        {
            m_objCurrent.SetActive(false);
        }
        m_objCurrent = null;

        m_animator.SetTrigger("equip");
        m_animator.SetInteger("weapon", 0); // enum 설정 필요.
    }

    public void Click_2HandSword()
    {
        if (m_objCurrent)
        {
            m_objCurrent.SetActive(false);
        }

        m_objCurrent = m_obj2HandSword;

        m_animator.SetTrigger("equip");
        m_animator.SetInteger("weapon", 1); // enum 설정 필요.
    }

    public void Click_Run()
    {
        if (m_objCurrent)
        {
            m_objCurrent.SetActive(false);
        }

        m_animator.SetTrigger("run");
        m_animator.SetInteger("weapon", 0); // enum 설정 필요.
    }

    public void Click_UnEquip()
    {
        if (m_objCurrent)
        {
            m_objCurrent.SetActive(false);
        }

        m_animator.SetTrigger("unarmed");
        m_animator.SetInteger("weapon", 0); // enum 설정 필요.
    }

    public void WeaponSwitch()
    {
        Debug.Log(" WeaponSwitch()  !!!");
        if(m_obj2HandSword)
        {
            m_obj2HandSword.SetActive(true);
        }

    }
}
