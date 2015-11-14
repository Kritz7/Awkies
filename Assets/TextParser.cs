using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;

public class TextParser : MonoBehaviour {

	public Vector3 topTextLocation;
	public Vector3 bottomTextLocation;

	public Text playerText;
	public Text dateText;
	public Text thoughtText;
	Text myText;

	List<string> playerTextHistory = new List<string>();
	List<string> dateTextHistory = new List<string>();

	void Awake()
	{
		myText = GetComponent<Text> ();

		playerText.text = "";
		dateText.text = "";
	}

	public void AddText(string line)
	{
		Debug.Log ("Added " + line);
		SendTextTo (line);
	}

	void SendTextTo(string line)
	{
		string textBeforeColon = line.Substring(0,line.IndexOf (":"));
		string textAfterColon = line.Substring(line.IndexOf (":")+1);

		switch (textBeforeColon.ToLower()) {
		case "player":
			playerTextHistory.Add(textAfterColon);
			MoveToBottom(playerText, dateText);
			StartCoroutine(buildText(playerText, textAfterColon));
			break;
		case "date":
			dateTextHistory.Add(textAfterColon);
			MoveToBottom(dateText, playerText);
			StartCoroutine(buildText(dateText, textAfterColon));
			break;
		case "mono":
			playerTextHistory.Add("*" + textAfterColon + "*");
			StartCoroutine(buildText(thoughtText, textAfterColon));
			break;
		}
	}

	void MoveToBottom(Text textObj, Text notTextObj)
	{
		textObj.transform.parent.gameObject.AddComponent<CoolAnimation> ().InitMoveAnimation (bottomTextLocation, CoolAnimation.LerpStyle.EaseOut, 0, 0.2f, true, true);
		notTextObj.transform.parent.gameObject.AddComponent<CoolAnimation> ().InitMoveAnimation (topTextLocation, CoolAnimation.LerpStyle.EaseOut, 0, 0.2f, true, true);
	}

	IEnumerator buildText(Text txtObj, string line)
	{
		var stringBuilder = new StringBuilder ();

		foreach (char c in line) {
			stringBuilder.Append (c);
			txtObj.text = stringBuilder.ToString ();
			yield return new WaitForSeconds (0.025f);
		}
	}
}
