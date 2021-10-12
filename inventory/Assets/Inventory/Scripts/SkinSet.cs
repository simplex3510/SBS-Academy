using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkinSet : MonoBehaviour
{
    public Animator m_animator;
    public List<GameObject> m_lstObjectReference;
    public GameObject m_currentObj;
    public SkinnedMeshRenderer m_boneSource;
    public SkinnedMeshRenderer m_defaultSkin;

    SkinSet m_SkinSet;

    public void Set_skin(int ix)
    {
        GameObject obj = m_lstObjectReference[ix];
        if (obj == null)
        {
            return;
        }
        if (m_currentObj != null)
        {
            m_currentObj.SetActive(false);
        }

        SkinnedMeshRenderer[] targets = m_currentObj.GetComponentInChildren<SkinnedMeshRenderer>();

        foreach (SkinnedMeshRenderer target in targets)
        {
            if (target != null)
            {
                target.bones = m_boneSource.bones;
                target.rootBone = m_boneSource.rootBone;
            }
        }

        if (m_defaultSkin != null)
        {
            m_defaultSkin.gameObject.SetActive(false);
        }
        
        if (m)
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
