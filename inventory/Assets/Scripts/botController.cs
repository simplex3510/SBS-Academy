using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AnimatorMoveEvent : UnityEvent<Vector3, Quaternion> { }

public class botController : MonoBehaviour
{
    public UnityEvent OnWeaponSwitch = new UnityEvent();
    public AnimatorMoveEvent OnMove = new AnimatorMoveEvent();
    public Animator m_animator;
    private void Awake()
    {
        if (m_animator == null)
            m_animator = GetComponent<Animator>();
    }

    void OnAnimatorMove()
    {
        if(m_animator)
        {
            OnMove.Invoke(m_animator.deltaPosition, m_animator.rootRotation);
        }
    }

    public void ev_hit()
    {
        Debug.Log("   Hit !!!!");
    }

    public void ev_WeaponSwitch()
    {
        Debug.Log("   ev_WeaponSwitch !!!!");
        OnWeaponSwitch.Invoke();
    }
}
