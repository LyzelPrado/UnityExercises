using UnityEngine;
using System.Collections;

public class iTweenExercise : MonoBehaviour {
	
	Hashtable ht = new Hashtable();
	
	void Awake(){
	ht.Add("x",3);
	ht.Add("time",4);
	ht.Add("delay",1);
	ht.Add("onupdate","myUpdateFunction");
	ht.Add("looptype",iTween.LoopType.pingPong);
}
	void Start(){
	iTween.MoveTo(gameObject,ht);
	}
	// Update is called once per frame
	void Update () {
		
}
}
