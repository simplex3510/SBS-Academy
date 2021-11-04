using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSkill00 : Weapon
{
    public Transform m_spawnPos;
    public Projectile m_projectile;

    protected override void PlaySkill()
    {
        Player p = m_owner.GetComponent<Player>();
        Debug.Log(" ½ºÀ® ¿¡´Ï");
        p.PlayAniSwing01();

        GameObject obj = ProjectileManager.instance.Spawn_playerSwing01(m_spawnPos.position);
        if (obj == null)
        {
            Debug.Log(" Spawn_playerSwing01 Null. ");
            return;
        }
        m_projectile = obj.GetComponent<Projectile>();
        m_projectile.m_damage = m_owner.GetComponent<UnitInfo>().m_data.m_atk;
        // m_projectile.SetFlipX(!p.m_isLeftLook);

        Invoke("EndSkill", 0.5f);

    }
    void EndSkill()
    {
        if (m_projectile == null)
        {
            Debug.Log(" m_projectile Null. ");
            return;
        }
        m_projectile.Release();

    }
}
