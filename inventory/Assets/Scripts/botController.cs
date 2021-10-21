using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botController : MonoBehaviour
{
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
}
