using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSword : Weapon
{

    private void Awake()
    {
//        m_WeaponAniType = E_WeaponAniType.armed_L;
    }
    
    public override void Set_Equip(ref Weapon _target_L, ref Weapon _target_R, 
        bool _isLeft, Weapon _sor, Animator _animator)
    {
        int weaponType = (int)m_WeaponAniType;
        if(_isLeft)
        {
            if (_target_L)
                _target_L.Set_Active(false);
            if (_target_R && _target_R.m_WeaponAniType != E_WeaponAniType.armed_R) 
                // WeaponAniType 이 듀얼 인지 확인. 아니면 꺼준다.
            {
                _target_R.Set_Active(false);
                _target_R = null;
            }
            _target_L = _sor;
        }
        else
        {
            if (_target_R)
                _target_R.Set_Active(false);
            if (_target_L && _target_L.m_WeaponAniType != E_WeaponAniType.armed_L)
            {
                _target_L.Set_Active(false);
                _target_L = null;
            }
            _target_R = _sor;
        }
        
        _animator.SetTrigger("Equip");
        _animator.SetInteger("Weapon", weaponType);
    }
}
