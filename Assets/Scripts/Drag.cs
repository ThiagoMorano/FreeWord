using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {
	Vector2 difference;

	public Transform lastParent = null;

	public void OnBeginDrag(PointerEventData evData) {
		Debug.Log("OnBeginDrag");

		lastParent = this.transform.parent;
		this.transform.SetParent(this.transform.parent.parent);
	//	difference = (this.transform.position as Vector2) - (evData.position as Vector2);

		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData evData) {
		this.transform.position = evData.position;
	}

	public void OnEndDrag(PointerEventData evData) {
		Debug.Log("OnEndDrag");

		this.transform.SetParent(lastParent);

		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
}
