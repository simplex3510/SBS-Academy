using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public ItemInfoRec m_data;
    public int m_count;

    public void AddCount(int n)
    {
        m_count += n;
    }
}
