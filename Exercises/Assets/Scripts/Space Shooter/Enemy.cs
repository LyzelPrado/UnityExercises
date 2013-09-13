using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float minSpeed = 5.0f;
	public float maxSpeed = 10.0f;
	int x,y,z;
	public float currentSpeed;
	
	// Use this for initialization
	void Start () 
	{
		y=14;
		z=7;
		x=Random.Range(-14, 14);
		transform.position= new Vector3(x, y, z);
		currentSpeed= Random.Range(minSpeed,maxSpeed);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		x=Random.Range(-14, 14);
		transform.Translate(-Vector3.up * currentSpeed * Time.deltaTime);
		
		
		if(transform.position.y < -10)
		{
			transform.position = new Vector3(x,y,z);
			currentSpeed = Random.Range(minSpeed,maxSpeed);
		}
	
	}
	
	void OnTriggerEnter(Collider collider)
	{	
		Vector3 enemyPos = new Vector3(x,y,z);
		Instantiate(gameObject, enemyPos, Quaternion.identity);
		
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
