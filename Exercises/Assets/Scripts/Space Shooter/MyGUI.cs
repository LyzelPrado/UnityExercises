using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour {

	void OnGUI()
	{
		GUI.Box(new Rect(100, 50, 1000,100), "Score : " + Player.score + "	Lives : " + Player.playerLives);
		
	}
}
