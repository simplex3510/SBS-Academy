using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotHand : MonoBehaviour
{
    public Image m_icon;
    public WeaponData m_equipWeaponData = null;

    public virtual void OnDrop(Image _icon)
    {

    }

    public void Unequip()
    {
        // ��� ���� UI ó��.
        m_icon.sprite = null;
        m_equipWeaponData = null;
    }
}
