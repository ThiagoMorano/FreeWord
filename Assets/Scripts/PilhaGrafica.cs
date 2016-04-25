using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(Pilha))]

public class PilhaGrafica : MonoBehaviour {

	public Transform[] positionNodes; //Posicao dos nodes na tela. Deve ser settado na cena
	//public int numberOfPositions;
	public int lastPositionUsed = -1;	  //Ultima posicao disponivel

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Tenta empilhar a carta na pilha real. Caso possivel, tambem a empilha na pilha grafica
	public bool GameEmpilha(NodeGrafico no) {

		char info;

		if( this.GetComponentInParent<Pilha>().Empilha(no.GetComponentInParent<Node>().Info) ) {
			//no.transform.SetParent(positionNodes[]
		}

		return false;
	}

	public bool GameDesempilha() {
		return false;
	}
}
