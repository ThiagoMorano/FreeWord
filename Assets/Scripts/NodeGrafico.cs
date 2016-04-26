using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//Cores possíveis das cartas
public enum Color { Vermelho, Cinza, Azul, Amarelo };

[RequireComponent(typeof(Node))]

public class NodeGrafico : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public Node node;

	public GameController gameController;
	public Transform lastParent = null;

	public PilhaGrafica pilhaQueSaiu;

	public bool beingDragged; 		 	//Se o node esta sendo arrastado
	public bool wasDropped = false;		//Se foi droppado em uma pilha
	//public bool beingHeld = false;	//Se esta sendo segurado
	public Color cor;				 //Cor da carta

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
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
		
			//Vira filho da última pilha
			this.transform.SetParent(lastParent);
			if(!wasDropped)
				lastParent.GetComponent<PilhaGrafica>().GameEmpilha(this);
			//Volta a bloquear raycasts
			GetComponent<CanvasGroup>().blocksRaycasts = true;
			beingDragged = false;
		}
	}

	/*//Quando o recebe um click completo.
	void OnMouseUpAsButton() {
		//Empilha()

		if(gameController.nodeBeingHeld != null) {
			if (isBase) {
				this.GetComponentInParent<PilhaGrafica>().GameEmpilha(this);  //GameController segurando um no e pilha esta vazia
				Debug.Log ("GC segura, pilha vazia");
			}
			else {
				if (isTopo) {
					this.GetComponentInParent<PilhaGrafica>().GameEmpilha(this); //GameController segurando no, e o topo e clicado
					Debug.Log ("GC segura, topo clicado");
				}
				else {
					//DEFAULT ACTION. Devolver pra pilha em que foi retirado?
					//Ou retirar que diminui o numero de jogadas?
				}
			}
		}
		else {
			if(isTopo) {
				this.GetComponentInParent<PilhaGrafica>().GameDesempilha();	//GameController sem no, e o topo e clicado
				Debug.Log ("GC NAO segura, topo clicado");
				//num jogadas --;
			}	
		}
	}*/
}