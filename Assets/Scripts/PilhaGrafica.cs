using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Pilha))]

public class PilhaGrafica : MonoBehaviour {
	public Pilha pilha;

	public Transform[] positionNodes; 	  //Posicao dos nodes na tela. Deve ser settado na cena
	//public int numberOfPositions;
	public int firstPositionAvailable = 0;	  //Primeira posicao disponivel

	public NodeGrafico baseNode;		  //O head node e um node invisivel, utilizado para verificar os casos de pilha vazia

	public GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Tenta empilhar a carta na pilha real. Caso possivel, tambem a empilha na pilha grafica
	public void GameEmpilha(NodeGrafico no) {
		if( firstPositionAvailable <= positionNodes.Length ) { //Apenas se a pilha nao estiver cheia
			if( /*this.GetComponent<Pilha>().Empilha(no.GetComponent<Node>().Info*/pilha.Empilha (no.node.Info) ) {
				no.beingHeld = false;

				//Torna o transform do node empilhado filho da posicao
				no.transform.SetParent (positionNodes[firstPositionAvailable]);
				no.transform.position = new Vector3 (0.0f, 0.0f, no.transform.position.z);

				gameController.isHoldingNode = false;
				gameController.nodeBeingHeld = null;

				no.isTopo = true;

				firstPositionAvailable++;
			}
		}

	}
	
	//Tenta desempilhar da pilha real
	public void GameDesempilha(/*NodeGrafico no*/) {
		char infoAux = '0';
		NodeGrafico no = this.positionNodes [firstPositionAvailable - 1].GetComponentInChildren<NodeGrafico> ();

		//Desempilha
		if( /*this.GetComponent<Pilha>().Desempilha(infoAux)*/ pilha.Desempilha (infoAux) ) {
			//transform do no nao e mais filho
			no.transform.parent = null;

			//GameController segura o no
			gameController.isHoldingNode = true;
			gameController.nodeBeingHeld = no;

			no.beingHeld = true;

			firstPositionAvailable--;
			if(firstPositionAvailable > 0) //Se ainda houver algum node na pilha, este torna-se topo
				positionNodes[firstPositionAvailable - 1].GetComponentInChildren<NodeGrafico>().isTopo = true;

		}
		else {
		
		}
	}
}
