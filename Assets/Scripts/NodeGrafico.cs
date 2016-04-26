using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Node))]

public class NodeGrafico : MonoBehaviour {
	public Node node;
	
	private Vector3 screenPoint; //Posicao do objeto na tela
	private Vector3 offset;

	public GameController gameController;

	public bool isTopo; 		 //Se o node e topo de pilha ou nao
	public bool isBase;			 //Se o node e a base da pilha grafica
	public bool beingHeld = false;		 //Se esta sendo segurado
	public int cor;				 //Cor da carta

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(beingHeld) {
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z) + offset) - new Vector3(0.0f, 1.1f, 0.0f);
		}
	}

	
	void OnMouseDown(){

	/*	if(gameController.nodeBeingHeld != null) {
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
		}*/

		/*if(gameController.isHoldingNode) {
			this.GetComponentInParent<PilhaGrafica>().GameEmpilha(this);
		}
		else {
			this.GetComponentInParent<PilhaGrafica>().GameDesempilha(this);	
		}*/

		//Desempilha()
		/*screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));*/
	}
	
	void OnMouseDrag(){
		/*
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;*/
	}

	//Quando o recebe um click completo.
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

		/*
		//Se o no clicado e topo, tenta desempilhar/empilhar da pilha grafica
		if(!isHead) {
			if(isTopo) {
				if(gameController.isHoldingNode) {
					this.GetComponentInParent<PilhaGrafica>().GameEmpilha(this);
				}
				else {
					this.GetComponentInParent<PilhaGrafica>().GameDesempilha(this);	
				}
			}
		}
		else {
			if(gameController.isHoldingNode) {
				this.GetComponentInParent<PilhaGrafica>().GameEmpilha(this);
			}
		}*/
	}
}