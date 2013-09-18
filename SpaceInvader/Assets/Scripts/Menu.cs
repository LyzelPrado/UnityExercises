using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public bool isExit;
	void OnClick()
	{
		if(isExit)
			Application.Quit();
		else
		Application.LoadLevel(1);
	}
}
