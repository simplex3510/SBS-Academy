using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
	public GameObject m_obj2HandSword;
	public GameObject m_objCurrent;
	public Animator m_animator;

	public void OnDrop(PointerEventData eventData)
	{
		// Debug.Log("OnDrop item :" + eventData.selectedObject.name);
		if (eventData.selectedObject)
		{
			eventData.selectedObject.transform.SetParent(this.transform);
			eventData.selectedObject.transform.localPosition = Vector3.zero;
			eventData.selectedObject.transform.localScale = Vector3.one;
			eventData.selectedObject.GetComponent<Image>().raycastTarget = true;

			if (eventData.selectedObject.tag == "Sword")
			{
				if (m_objCurrent)
				{
					m_objCurrent.SetActive(false);
				}

				m_objCurrent = m_obj2HandSword;

				m_animator.SetTrigger("equip");
				m_animator.SetInteger("weapon", 1); // enum 설정 필요.
			}

			eventData.selectedObject = null;
		}
	}
}
