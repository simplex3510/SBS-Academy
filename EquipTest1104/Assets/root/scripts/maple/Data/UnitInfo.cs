using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo : MonoBehaviour
{
    public UnitInfoRec m_data;

    public void ResetHP()
    {
        m_data.m_currentHP = m_data.m_maxHP;
    }
}
