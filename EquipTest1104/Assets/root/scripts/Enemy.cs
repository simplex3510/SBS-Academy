using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public UnitInfo m_unitInfo;

    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }
}
