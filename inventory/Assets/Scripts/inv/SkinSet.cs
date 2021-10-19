using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSet : MonoBehaviour
{
    public Animator m_animator;
    public List<GameObject> m_lstObjectReference;
    public GameObject m_currentObj;
    public SkinnedMeshRenderer m_boneSource;
    public SkinnedMeshRenderer m_defaultSkin;


    public void Set_skin(int ix)
    {
        GameObject obj = m_lstObjectReference[ix];
        if (obj == null)
            return;

        if (m_currentObj != null)
            m_currentObj.SetActive(false);

        m_currentObj = obj;

        SkinnedMeshRenderer[] targets = m_currentObj.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer target in targets)
        {
            if (target != null)
            {
                target.bones = m_boneSource.bones;
                target.rootBone = m_boneSource.rootBone;
            }

            if (m_defaultSkin != null)
            {
                m_defaultSkin.gameObject.SetActive(false);
            }
        }
        if (m_animator != null)
        {
            m_animator.Rebind();
               
        }
        m_currentObj.SetActive(true);
    }
    
}
