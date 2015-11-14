using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
	public static GameFlow mainFlow;

	public Node startNode;
	Node currentNode;

	void Awake()
	{
		mainFlow = this;
	}

	void Start()
	{
		currentNode = startNode;
		MoveToNode (currentNode);
	}

	public void MoveToNode(Node n)
	{
		UIScreen.mainScreen.PopulateButtons (n);
		UIScreen.mainScreen.GetComponentInChildren<Text> ().text = n.text;
	}



}
