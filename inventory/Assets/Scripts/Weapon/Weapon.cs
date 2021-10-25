using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_WeaponAniType
{
    unarmed = 0,
    TwoHandSword,
    armed_L,
    armed_R,
}
public enum E_WeaponID
{
    unarmed = 0,
    TwoHandSword,
    sword_L,
    sword_R,
    shield_L,
    shield_R,

}
public class Weapon : MonoBehaviour
{
    public E_WeaponAniType m_WeaponAniType = E_WeaponAniType.unarmed;
    public E_WeaponID m_weaponID = E_WeaponID.unarmed;

    public void Set_Active(bool b)
    {
        gameObject.SetActive(b);
    }
    public bool Get_Active()
    {
        return gameObject.activeSelf;
    }
    public virtual void Set_Equip(ref Weapon _target_L, ref Weapon _target_R,
        bool _isLeft, Weapon _sor, Animator _animator)
    {
        if (_target_L)
            _target_L.Set_Active(false);
        if (_target_R)
            _target_R.Set_Active(false);

        int weaponType = (int)E_WeaponAniType.unarmed;
        _target_R = _target_L = null;
        _animator.SetTrigger("Equip");
        _animator.SetInteger("Weapon", weaponType);
    }
}
