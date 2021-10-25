using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponTwoHandSword : Weapon
{

    private void Awake()
    {
        m_WeaponAniType = E_WeaponAniType.TwoHandSword;
    }
    
    public override void Set_Equip(ref Weapon _target_L, ref Weapon _target_R, 
        bool _isLeft, Weapon _sor, Animator _animator)
    {
        Debug.Log(" WeaponTwoHandSword [" + _sor +"]");
        if (_target_L)
            _target_L.Set_Active(false);
        if (_target_R)
            _target_R.Set_Active(false);

        int weaponType = (int)m_WeaponAniType;
        if(_isLeft)
        {
            _target_L = _sor;
            _target_R = null;
        }
        else
        {
            _target_L = null;
            _target_R = _sor;
        }
       
        _animator.SetTrigger("Equip");
        _animator.SetInteger("Weapon", weaponType);

        Debug.Log(" _target_L [" + _target_L + "]");
        Debug.Log(" _target_R [" + _target_R + "]");
    }
}
