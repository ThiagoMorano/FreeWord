using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public bool isHoldingNode = false;		//Se uma carta esta sendo segurada
	public NodeGrafico nodeBeingHeld = null;		//A carta sendo segurada


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HoldCard(NodeGrafico node) {
		isHoldingNode = true;
		nodeBeingHeld = node;
	}
}
