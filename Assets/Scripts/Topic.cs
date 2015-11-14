using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Topic : MonoBehaviour
{
	public List<Answer> answers = new List<Answer> ();

	void Awake()
	{
		PopulateAnswersFromChildren ();
	}

	void PopulateAnswersFromChildren()
	{
		foreach (Transform t in transform) {
			if(t.GetComponent<Answer>()) answers.Add(t.GetComponent<Answer>());
		}

		/*
		foreach (Answer a in GetComponentsInChildren<Answer>()) {
			answers.Add(a);
		}
		*/
	}
}
