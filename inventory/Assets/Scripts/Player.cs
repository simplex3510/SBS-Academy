using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InvenData m_invenData;
    public botController m_botController;
    public Transform m_equip_R;
    public List<Weapon> m_objWeapons;
    public Weapon m_currentWeapon_L;
    public Weapon m_currentWeapon_R;


    private void Start()
    {
        m_invenData.LoadData();
    }

    public void OnWeaponSwitch()
    {
        Debug.Log("  OnWeaponSwitch()");
        if (m_currentWeapon_L)
            m_currentWeapon_L.Set_Active(true);
        if (m_currentWeapon_R)
            m_currentWeapon_R.Set_Active(true);
    }

    public Weapon Get_Weapon(E_WeaponID id)
    {
        for(int ix=0; ix<m_objWeapons.Count; ix++)
        {
            if (m_objWeapons[ix].m_weaponID == id)
            {
                return m_objWeapons[ix];
            }
        }
        return null;
    }

    public void Click_equip2HandSword()
    {
        WeaponTwoHandSword select = (WeaponTwoHandSword) Get_Weapon(E_WeaponID.TwoHandSword);
        select.Set_Equip(ref m_currentWeapon_L, ref m_currentWeapon_R, false, select, m_botController.m_animator);

    }
    public void Click_equipSword_L()
    {
        WeaponSword select = (WeaponSword)Get_Weapon(E_WeaponID.sword_L);
        select.Set_Equip(ref m_currentWeapon_L, ref m_currentWeapon_R, true, select, m_botController.m_animator);
    }
    public void Click_equipSword_R()
    {
        WeaponSword select = (WeaponSword)Get_Weapon(E_WeaponID.sword_R);
        select.Set_Equip(ref m_currentWeapon_L, ref m_currentWeapon_R, false, select, m_botController.m_animator);
    }
    public void Click_equipUnarmed()
    {
        Weapon select = Get_Weapon(E_WeaponID.unarmed);
        select.Set_Equip(ref m_currentWeapon_L, ref m_currentWeapon_R, false, null, m_botController.m_animator);
    }

    public void OnMove(Vector3 _pos, Quaternion _rot)
    {
        Debug.Log(" Delta pos:" + _pos + ", _rot:" + _rot);

        transform.position += _pos;
        transform.rotation = _rot;
    }
}
