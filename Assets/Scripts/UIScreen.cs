using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour
{
	public static UIScreen mainScreen;
	public GameObject buttonPrefab;

	void Awake ()
	{
		mainScreen = this;
	}

	public void PopulateButtons(Node n)
	{
		int buttonIndex = 0;

		Debug.Log (n);

		List<Answer> currentAnswers = n.GetAnswers();

		foreach (Answer a in currentAnswers)
		{
			Button b = CreateButton(a.text, buttonIndex, currentAnswers.Count);

			float affect = a.affect;

			b.onClick.AddListener(() => {
				Actor.mainCharacter.stress += affect;
				GameFlow.mainFlow.MoveToNode(n.nextNodes[0]);
			});
			buttonIndex++;
		}
	}

	Button CreateButton(string text, int buttonIndex, int buttonCount)
	{
		Rect buttonRect = buttonPrefab.GetComponent	<RectTransform> ().rect;


		float buttonXPos = (buttonIndex - (buttonCount/2)) * (buttonRect.width + 10f);
		Vector3 buttonPos = new Vector3(buttonXPos, 0 - buttonRect.height, 0);

		GameObject newButton = GameObject.Instantiate(buttonPrefab,
		                                              buttonPos,
		                                              Quaternion.identity) as GameObject;

		newButton.transform.SetParent (this.transform, false);

		newButton.GetComponentInChildren<Text> ().text = text;

		newButton.GetComponent<Image>().color = new Color(Random.Range(0.7f,1), Random.Range(0.7f,1), Random.Range(0.7f,1));

		return newButton.GetComponent<Button>();
	}
}
