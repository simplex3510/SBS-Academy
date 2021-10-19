using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInfoRec  // struct 인 경우 값이 복사되어 변수로 전달 되고,
                          // class 인 경우 인스턴스 참조(주소)형으로 전달 된다.
{
    public string m_itemID;  // 
    public string m_iconName;  // file name
    public string m_itemName;  // 한글 이름 가능.
    public string m_desc;
    public int m_actionType; // 스킨 타입, 무기 타입, 방어구 등등
                             // x00xx 착용장비아님, 100 한손 착용 장비, 200 양손 착용,
                             // 300 머리 착용, 400 어께 착용, 500 상반신, 600 상하일체형, 700바지, 800신발,
                             // 900목걸이, 1000반지, 11허리띠,
    public float m_value1;  // 액션 타입 적용 값1
    public float m_value2;  // 액션 타입 적용 값2

    //public void ResetData()  // class 형으로 하는 경우 null 체크로 변경.
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

