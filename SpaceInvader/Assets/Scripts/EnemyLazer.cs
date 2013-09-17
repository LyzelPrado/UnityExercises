using UnityEngine;
using System.Collections;

public class EnemyLazer : MonoBehaviour {

	public GameObject [] Enemy;
	// Use this for initialization
	void Start () {
		
		foreach (GameObject enem in Enemy)
		transform.position = new Vector3(enem.transform.position.x, enem.transform.position.y - 1, enem.transform.position.z);
		
	}

	// Update is called once per frame
	void Update () {

		iTween.MoveBy(gameObject, iTween.Hash("y", -20f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none, "delay", 0f, "speed",5f));

		if(transform.position.y == -1)
			DestroyObject(this.gameObject);


	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.CompareTag("Player"))
		{
	
			Destroy(this.gameObject);
		}
	}
}