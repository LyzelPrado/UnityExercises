using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	/*public static float y  = -3f;
	public static float x = 1.0f;
	float leftBoundary = 1f;
	float rightBoundary = 23f;*/
	
	float startTime;
	bool movingRight = true;

	public GameObject EnemyLazerFab;
	
    public float minShootDelay = 1.0f;
    public float maxShootDelay = 7.0f;
    float nextShootTime = 0.0f;
	
	public float minSpeed = 3.0f;
	public float maxSpeed = 5.0f;
	int x,y,z;
	public float currentSpeed;
	

	
	// Use this for initialization
	void Start () 
	{
		this.nextShootTime = Random.Range(minShootDelay, maxShootDelay)* 1f;
		y=16;
		z=0;
		x=Random.Range(-15, 15);
		transform.position= new Vector3(x, y, z);
		currentSpeed= Random.Range(minSpeed,maxSpeed);
		

	}

	// Update is called once per frame
	void Update () 
	{
		RandomEnemy();
		EnemyAttack();
		
		
	
		
	}

	void OnTriggerEnter(Collider collider)
	{	
		Vector3 enemyPos = new Vector3(x,y,z);
		Instantiate(gameObject, enemyPos, Quaternion.identity);

		
		if(collider.gameObject.CompareTag("PlayerLazer"))
		{
			Destroy(this.gameObject);
		}

	
	}
	

	void EnemyAttack()
	{
		 if (Time.time > nextShootTime)
        {
			Vector3 target = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
			Instantiate(EnemyLazerFab, target, Quaternion.identity);
            nextShootTime = (Time.time + Random.Range(minShootDelay, maxShootDelay)) * 5f;
		
        }
	}
	
	void RandomEnemy()
	{
		x=Random.Range(-15, 15);
		transform.Translate(-Vector3.up * currentSpeed * Time.deltaTime);
		
		
		if(transform.position.y < -10)
		{
			transform.position = new Vector3(x,y,z);
			currentSpeed = Random.Range(minSpeed,maxSpeed);
		}
	}

	
}

