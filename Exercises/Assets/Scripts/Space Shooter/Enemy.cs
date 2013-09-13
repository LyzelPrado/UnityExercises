using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float minSpeed = 5.0f;
	public float maxSpeed = 10.0f;
	//int x,y,z;
	public float currentSpeed;
	bool fire = true;
	public GameObject EnemyLazer;
	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{	
			iTween.MoveBy(gameObject, iTween.Hash("x", 20f, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong, "delay", 0f, "speed",5f));

		if(fire){
		
			Vector3 projectPos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
			Instantiate(EnemyLazer, projectPos, Quaternion.identity);
		}
		
		
	
	}
	
	void OnTriggerEnter(Collider collider)
	{	
		
		if(collider.gameObject.CompareTag("Lazer"))
		{
			Destroy(this.gameObject);
		}
		
		if(collider.gameObject.CompareTag("Player"))
		{
			Destroy(this.gameObject);
		}
	}
}
