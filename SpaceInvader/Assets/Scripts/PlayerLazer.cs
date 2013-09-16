using UnityEngine;
using System.Collections;

public class PlayerLazer : MonoBehaviour {

	public float projectileSpeed = 10.0f;
	//public GameObject Enemy;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		iTween.MoveBy(gameObject, iTween.Hash("y", 20f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.none, "delay", 0f, "speed",5f));

		if(transform.position.y > 15)
			DestroyObject(this.gameObject);


	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.CompareTag("Enemy"))
		{
			Player.score += 5;
			Destroy(this.gameObject);
		}
	}
}