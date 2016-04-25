using UnityEngine;
using System.Collections;

enum Color {
	Azul, Cinza, Vermelho, Amarelo
};

[RequireComponent(typeof(Node))]

public class NodeGrafico : MonoBehaviour {

	private Vector3 screenPoint; //Posicao do objeto na tela
	private Vector3 offset;
	private bool sobrePilha;	 //Se a carta esta em cima de uma pilha quando arrastada

	public int cor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnMouseDown(){

		//Desempilha()
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

	void OnMouseUp() {
		//Empilha()

	}

	void OnTriggerStay(Collider hit) {
		if(hit.GetComponent<PilhaGrafica>() != null) {
			sobrePilha = true;
			Debug.Log ("Sobre pilha");
		}
		
	}
}
