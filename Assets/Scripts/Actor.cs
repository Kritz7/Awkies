using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	public static Actor mainCharacter;
	public bool isMain;
	public float stress = 0;


	void Awake()
	{
		if (isMain)
			mainCharacter = this;
	}


}
