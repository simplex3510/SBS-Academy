using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class DragImage : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Transform _startParent;
	public WeaponData m_setDragData;

	public void OnBeginDrag(PointerEventData eventData)
	{
		_startParent = transform.parent;
		transform.SetParent(UIMgr.instance.m_canvas.transform);
		_startParent.localScale = Vector3.one;

		GetComponent<Image>().raycastTarget = false;
		eventData.selectedObject = this.gameObject;

		Debug.Log(" OnBeginDrag" + m_setDragData);
		m_setDragData.Set_DragData();
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;

	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log(" OnEndDrag !");
		if(eventData.selectedObject == null)
        {
			return;
        }
		transform.SetParent(_startParent);
		transform.localPosition = Vector3.zero;
		GetComponent<Image>().raycastTarget = true;
	}
}