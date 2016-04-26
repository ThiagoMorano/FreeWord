using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Cores possíveis das cartas e pilhas.
//Ha apenas pilhas verdes, que sao as auxiliares
public enum Color { Vermelho, Azul, Cinza, Amarelo, Verde };

public class GameController : MonoBehaviour {

	public int numJogadas;		//Numero maximo de jogadas
	public Text jogadas;
	public GameObject winMessage;
	public GameObject loseMessage;
	public string[] palavras = new string[4];
/*	public char[] palavraVermelha = new char[6];
	public char[] palavraAzule = new char[4];
	public char[] palavraCinza = new char[5];
	public char[] palavraAmarela = new char[5];*/

	public PilhaGrafica[] pilhas;

	private bool win = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		jogadas.text = "Jogadas restantes: " + numJogadas.ToString ();

		if(numJogadas == 0) {
			Lose ();
		}
		else if (win){
			Win ();
		}
	}

	public void checkWinCondition() {
		Debug.Log ("Checking win condition");
		bool igual = false;
		int i = 0;
		foreach(PilhaGrafica p in pilhas) {
			igual = p.checkWin (i);
			if(!igual)
				break;
			i++;
		}
		if (!igual)
			win = false;
		else
			win = true;
	}

	public void Win() {
		win = false;
		winMessage.SetActive (true);
	}
	public void Lose() {
		loseMessage.SetActive (true);	
	}
}
