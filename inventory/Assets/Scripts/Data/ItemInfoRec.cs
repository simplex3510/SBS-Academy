using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfoRec  // struct �� ��� ���� ����Ǿ� ������ ���� �ǰ�,
                          // class �� ��� �ν��Ͻ� ����(�ּ�)������ ���� �ȴ�.
{
    public string m_itemID;  // 
    public string m_iconName;  // file name
    public string m_itemName;  // �ѱ� �̸� ����.
    public string m_desc;
    public int m_actionType; // ��Ų Ÿ��, ���� Ÿ��, �� ���
                             // x00xx �������ƴ�, 100 �Ѽ� ���� ���, 200 ��� ����,
                             // 300 �Ӹ� ����, 400 � ����, 500 ��ݽ�, 600 ������ü��, 700����, 800�Ź�,
                             // 900�����, 1000����, 11�㸮��,
    public float m_value1;  // �׼� Ÿ�� ���� ��1
    public float m_value2;  // �׼� Ÿ�� ���� ��2

    //public void ResetData()  // class ������ �ϴ� ��� null üũ�� ����.
    //{
    //    m_itemID = "";
    //    m_iconName = "";
    //    m_itemName = "";
    //}
}

[System.Serializable]
public class ItemInfoTable
{
    public List<ItemInfoRec> m_dataList;
}

