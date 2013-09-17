using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		UILabel score = GameObject.Find("NumScore").GetComponent<UILabel>();
		score.text = Player.score.ToString();
		
		UILabel lives = GameObject.Find("NumLives").GetComponent<UILabel>();
		lives.text = Player.playerLives.ToString();
	
	}
}
