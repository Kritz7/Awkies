using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{

	public string text;
	public List<Node> nextNodes = new List<Node>();

	public List<Answer> GetAnswers()
	{
		Debug.Log (name + " getting answers");
		return new List<Answer>(GetComponentsInChildren<Answer>());
	}
}
