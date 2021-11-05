using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject m_obj2HandSword;
    public GameObject m_objSword_L;
    public GameObject m_objSword_R;

    public GameObject m_objCurrent_L;
    public GameObject m_objCurrent_R;

    public Animator m_animator;

    public List<Weapon> m_lstSkill;
    public UnitInfo m_unitInfo;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            PlaySkill(0);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopSkill(0);
        }
    }

    public void PlaySkill(int _ixClassSkill)
    {
        int ix = _ixClassSkill - m_unitInfo.m_data.m_classIndex;
        m_lstSkill[ix].StartFire();
    }
    public void StopSkill(int _ixClassSkill)
    {
        int ix = _ixClassSkill - m_unitInfo.m_data.m_classIndex;
        m_lstSkill[ix].StopFire();
    }

    public void PlayAniSwing01()
    {
        m_animator.SetTrigger("attack1");
        Debug.Log(" PlayAniSwing01");
    }

    public void TakeDamage(float _val)
    {
        Debug.Log(" TakeDamage !!!" + _val);
    }
    public void Click_leftUnequip()
    {
        if(m_objCurrent_L)
        {
            m_objCurrent_L.SetActive(false);
            m_objCurrent_L = null;
        }
        if(m_objCurrent_R == null) // 두다 널이면 Click_unarmed()
        {
            Click_unarmed();
        }
    }
    public void Click_rightUnequip()
    {
        if (m_objCurrent_R)
        {
            m_objCurrent_R.SetActive(false);
            m_objCurrent_R = null;
        }
        if (m_objCurrent_L == null) // 두다 널이면 Click_unarmed()
        {
            Click_unarmed();
        }
    }

    public bool Equip_L_currentDragData()
    {
        WeaponData weaponData = GameMgr.instance.m_currentDragData;
        if (weaponData == null)
            return false;

        if(weaponData.m_weaponName == "2HandSword")
        {
            return false;
        }else if(weaponData.m_weaponName == "Sword")
        {
            Click_Sword_L();
            return true;
        }
        return false;
    }
    public bool Equip_R_currentDragData()
    {
        WeaponData weaponData = GameMgr.instance.m_currentDragData;
        if (weaponData == null)
            return false;

        Debug.Log("weaponData.m_weaponName :" + weaponData.m_weaponName);

        if (weaponData.m_weaponName == "2HandSword")
        {
            Debug.Log("weaponData.m_weaponName :" + weaponData.m_weaponName);

            Click_2HandSword();
            return true;
        }
        else if (weaponData.m_weaponName == "Sword")
        {
            Click_Sword_R();
            return true;
        }
        return false;
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
        m_objCurrent_R = m_objCurrent_R = null;

        m_animator.SetTrigger("equip");
        m_animator.SetInteger("weapon", 0); // enum 설정 필요.
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
            m_objCurrent_L = null;
        }

        m_objCurrent_R = m_obj2HandSword;

        m_animator.SetTrigger("equip");
        m_animator.SetInteger("weapon", 1); // enum 설정 필요.
    }
    public void Click_Sword_L()
    {
        if (m_objCurrent_R)
        {
            if(!m_objCurrent_R.CompareTag("DualType"))
            {
                m_objCurrent_R.SetActive(false);
                m_objCurrent_R = null;
            }
        }
        if (m_objCurrent_L)
        {
            m_objCurrent_L.SetActive(false);
            
        }
        m_objCurrent_L = m_objSword_L;

        m_animator.SetTrigger("equip");
        m_animator.SetInteger("weapon", 2); // enum 설정 필요.
    }
    public void Click_Sword_R()
    {
        if (m_objCurrent_R)
        {
            m_objCurrent_R.SetActive(false);
        }
        if (m_objCurrent_L)
        {
            if (!m_objCurrent_L.CompareTag("DualType"))
            {
                m_objCurrent_L.SetActive(false);
                m_objCurrent_L = null;
            }
        }
        m_objCurrent_R = m_objSword_R;

        m_animator.SetTrigger("equip");
        m_animator.SetInteger("weapon", 3); // enum 설정 필요.
    }


    public void ev_WeaponSwitch()
    {
        Debug.Log(" ev_WeaponSwitch()  !!!");
        if(m_objCurrent_R)
        {
            m_objCurrent_R.SetActive(true);
        }
        if (m_objCurrent_L)
        {
            m_objCurrent_L.SetActive(true);
        }
    }
    public void FootR()
    {

    }
    public void FootL()
    {

    }
}
