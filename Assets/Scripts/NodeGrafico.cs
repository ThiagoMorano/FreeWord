using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Node))]

public class NodeGrafico : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public Node node;

	public GameController gameController;
	public Transform lastParent = null;

	public PilhaGrafica pilhaQueSaiu;

	public bool beingDragged; 		 	//Se o node esta sendo arrastado
	public bool wasDropped = false;		//Se foi droppado em uma pilha

	public Color cor;					 //Cor da carta

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
		char[] letter = this.GetComponentInChildren<Text> ().text.ToCharArray ();
		node.Info = letter[0];
	}

	//
	public void OnBeginDrag(PointerEventData evData) {
		//Debug.Log("OnBeginDrag");
		//if(isTopo) { //Se for topo, drag o card
		if(evData.pointerDrag.GetComponent<NodeGrafico>() != null) {
			pilhaQueSaiu = this.transform.parent.GetComponent<PilhaGrafica>();
			wasDropped = false;
			if(pilhaQueSaiu.pilha.Topo == this.node) {
				lastParent = this.transform.parent;
				lastParent.GetComponent<PilhaGrafica>().GameDesempilha();
				this.transform.SetParent(this.transform.parent.parent);
				
				beingDragged = true;

				GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
			else {
				Debug.Log("Não é topo");
			}
		}
	}


	public void OnDrag(PointerEventData evData) {
		if(evData.pointerDrag.GetComponent<NodeGrafico>() != null) {
			if(beingDragged) {
				this.transform.position = evData.position;
			}
		}
	}


	public void OnEndDrag(PointerEventData evData) {
		if(beingDragged) {
			Debug.Log("OnEndDrag");
		
			this.transform.SetParent(lastParent);
			if(!wasDropped){
				//Vira filho da última pilha
				lastParent.GetComponent<PilhaGrafica>().GameEmpilha(this);
			}
			//Volta a bloquear raycasts
			GetComponent<CanvasGroup>().blocksRaycasts = true;
			beingDragged = false;
			pilhaQueSaiu = null;
			wasDropped = false;
		}
	}
}