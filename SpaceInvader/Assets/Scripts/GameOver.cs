using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	


	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		
	
		UILabel score = GameObject.Find("FinalScore").GetComponent<UILabel>();
		score.text = Player.score.ToString();
		StartCoroutine(BackToMain());
	
		
	}
	
	IEnumerator BackToMain()
	{
	    yield return new WaitForSeconds(3.0f);
	    Application.LoadLevel(0);
		Player.score = 0;
		Player.playerLives = 3;
	}

	
}
