using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Pilha))]

public class PilhaGrafica : MonoBehaviour, IDropHandler {
	public Pilha pilha;

	//public Transform[] positionNodes; 	  //Posicao dos nodes na tela. Deve ser settado na cena
	//public int numberOfPositions;
	public int numElementos = 0;	  	 //Número de elementos
	public NodeGrafico[] cardsNaPilha;	 //Lista de cards na pilha. Deve ser inicialmente settado na cena
	//public NodeGrafico baseNode;		  //O head node e um node invisivel, utilizado para verificar os casos de pilha vazia

	public GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}

	//Quando um item e arrastado para dentro para uma pilha grafica
	public void OnDrop (PointerEventData evData) {
		if(evData.pointerDrag.GetComponent<NodeGrafico>() != null) {
			Debug.Log (evData.pointerDrag.name + "was dropped on " + gameObject.name);
			NodeGrafico no = evData.pointerDrag.GetComponent<NodeGrafico>();
			
			if(this != no.lastParent) { //Se não saiu da mesma pilha
				if(!pilha.Cheia()) {
					GameEmpilha(no);
					no.wasDropped = true;
				}
			}
		}
	}

	//Tenta empilhar a carta na pilha real. Caso possivel, tambem a empilha na pilha grafica
	public void GameEmpilha(NodeGrafico no) {
		Debug.Log("GameEmpilha chamado.");

		//if( pilha.Empilha (no.node.Info) ) {
		if( pilha.Empilha (no.node) ) {
			Debug.Log("No Empilhado");

			no.lastParent = this.transform;
			cardsNaPilha[numElementos] = no;
			numElementos++;
			//if(no.pilhaQueSaiu != this) 
			//num jogadas --
		}
	}
	
	//Tenta desempilhar da pilha real
	public void GameDesempilha(/*NodeGrafico no*/) {
		char infoAux = '0';
		//NodeGrafico no = this.positionNodes [firstPositionAvailable - 1].GetComponentInChildren<NodeGrafico> ();

		//Desempilha
		if( /*this.GetComponent<Pilha>().Desempilha(infoAux)*/ pilha.Desempilha (infoAux) ) {
			//transform do no nao e mais filho
			//no.transform.parent = null;

			numElementos--;
			cardsNaPilha[numElementos] = null;
		}
		else {
		
		}
	}
}
