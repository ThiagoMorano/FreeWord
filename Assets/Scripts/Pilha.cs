using UnityEngine;
using System.Collections;

class Pilha : MonoBehaviour {
	Node Topo = null;
	int elementos = 0;

	public bool Vazia() {
		if(Topo == null)
			return true;
		else
			return false;
	}

	public bool Cheia() {
		if(elementos == 10)
			return true;
		else
			return false;
	}

	public bool Empilha(char X) {
		Node PAux = new Node();
		PAux.Info = X;

		if(this.Cheia())
			return false;
		else if(Vazia()) {
			Topo = PAux;
			Topo.Next = null;
			elementos++;

			return true;
		} else {
			PAux.Next = Topo;
			Topo = PAux;
			PAux = null;
			elementos++;

			return true;
		}
	}

	public bool Desempilha(char X) {
		Node PAux = new Node();
		PAux.Info = X;

		if(Vazia()) {
			return false;
		} else if (elementos == 1 ){
			X = Topo.Info;
			Topo = null;
			Topo.Next = null;
			elementos--;

			return true;
		} else {
			PAux = Topo;
			X = Topo.Info;
			Topo = Topo.Next;
			PAux = null;
			elementos--;

			return true;
		}
	}
}
