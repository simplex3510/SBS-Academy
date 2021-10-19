using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowTarget : MonoBehaviour
{
    public Transform m_target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //float m_updateTime = 0;
    //float m_moveDur = 0.5f;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_target != null)
        {
            transform.position = Vector3.Lerp(transform.position, m_target.position, 0.5f);
        }
    }
}
