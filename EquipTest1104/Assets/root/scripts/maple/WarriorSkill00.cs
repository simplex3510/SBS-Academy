using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSkill00 : Weapon
{
    public Transform m_spawnPos;
    public Projectile m_projectile;
    public float m_delaySpawnPrj = 0.3f;
    protected override void PlaySkill()
    {
        Player p = m_owner.GetComponent<Player>();
        Debug.Log(" ½ºÀ® ¿¡´Ï");
        p.PlayAniSwing01();


        Invoke("Spawn_Projectile", m_delaySpawnPrj);
        Invoke("EndSkill", m_attackRate-0.1f);

    }

    void Spawn_Projectile()
    {
        GameObject obj = ProjectileManager.instance.Spawn_playerSwing01(m_spawnPos);
        if (obj == null)
        {
            Debug.Log(" Spawn_playerSwing01 Null. ");
            return;
        }
        m_projectile = obj.GetComponent<Projectile>();
        m_projectile.m_damage = m_owner.GetComponent<UnitInfo>().m_data.m_atk;
        //=============        m_projectile.SetFlipX(!p.m_isLeftLook);
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
