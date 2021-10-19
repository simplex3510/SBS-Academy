using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Button_inven m_itemBeingDragged;
    Transform _startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_itemBeingDragged = this.transform.GetComponentInParent<Button_inven>();
        if(m_itemBeingDragged == null || m_itemBeingDragged.m_invenDataRec == null
            || string.IsNullOrEmpty(m_itemBeingDragged.m_invenDataRec.m_itemID))
        {
            Debug.Log("m_itemBeingDragged == null, m_invenDataRec null �������� ���(��ĭ)");
            m_itemBeingDragged = null;
            return;
        }

        _startParent = transform.parent;
        transform.SetParent(UIMgr.instance.m_canvas.transform);
        _startParent.localScale = Vector3.one;

        GetComponent<Image>().raycastTarget = false;    // UI �̺�Ʈ ó�� ���� ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(m_itemBeingDragged == null)
        {
            return;
        }

        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(m_itemBeingDragged == null)
        {
            return;
        }

        Debug.Log("OnEndDrag!");

        transform.SetParent(_startParent);
        transform.localPosition = Vector3.zero;
        m_itemBeingDragged = null;
        GetComponent<Image>().raycastTarget = false;
    }
}
