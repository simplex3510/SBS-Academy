using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class DropImage : MonoBehaviour, IDropHandler
{
	public SlotHand m_owner;
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("OnDrop item :" + eventData.selectedObject.name);
		if(eventData.selectedObject)
        {
			m_owner.OnDrop(eventData.selectedObject.GetComponent<Image>(), GameMgr.instance.Get_player().m_dragData);

			//eventData.selectedObject.transform.parent = this.transform;
			//eventData.selectedObject.transform.localPosition = Vector3.zero;
			//eventData.selectedObject.GetComponent<Image>().raycastTarget = true;

			//eventData.selectedObject = null;

			
		}
	}

}