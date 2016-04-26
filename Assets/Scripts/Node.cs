using UnityEngine;
using System.Collections;

public class Node : ScriptableObject /*: MonoBehaviour */{
	public char Info = '0';
	public Node Next = null;

	public Node(char _info, Node _next) {
		Info = _info;
		Next = _next;
	}
}
