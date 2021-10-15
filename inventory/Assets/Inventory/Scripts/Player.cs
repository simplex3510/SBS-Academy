using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InvenData m_invenData;

    private void Start()
    {
        m_invenData.LoadData();
    }
}
