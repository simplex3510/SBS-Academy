using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject m_owner;
    public bool m_isOneShot = false;
    public float m_attackRate = 1f;
    public bool m_isFiring = false;
    public bool m_currentFire = false;

    float updateRate = 0;
    private void Awake()
    {
        if (m_owner == null)
            m_owner = transform.parent.gameObject;
    }
    private void FixedUpdate()
    {
        if (m_isFiring)
        {
            updateRate += Time.deltaTime;
            if (m_attackRate <= updateRate) // m_attackRate 동안 한번씩 처리 되게.
            {
                if (m_isOneShot)
                    m_currentFire = false;

                updateRate = 0;
                PlayFire(m_currentFire);
            }
        }
    }
    void PlayFire(bool _isFire)
    {
        m_currentFire = _isFire;
        if (m_currentFire)
        {
            PlaySkill(); // 자식 클레스에서 구현.
        }
        m_isFiring = m_currentFire;
    }
    protected virtual void PlaySkill()
    {
    }
    public void StartFire()
    {
        if (m_isFiring == m_currentFire)
        {
            m_isFiring = true;
            PlayFire(m_isFiring);
        }
        else
        {
            m_currentFire = true;
        }
    }
    public void StopFire()
    {
        m_currentFire = false;
    }
}
