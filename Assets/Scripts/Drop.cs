using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler {

	public void OnDrop (PointerEventData evData) {

		Debug.Log (evData.pointerDrag.name + "was dropped on " + gameObject.name);

		Drag d = evData.pointerDrag.GetComponent<Drag>();
		if(d != null) {
			d.lastParent = this.transform;
		}
		//ev.Data.pointerDrag.GetComponent<CanvasGroup>().blocksRaycast = true;
	}
}