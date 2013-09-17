using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public static float y  = -3f;
	public static float x = 1.0f;
	float leftBoundary = 1f;
	float rightBoundary = 23f;
	
	float startTime;
	bool movingRight = true;

	public GameObject EnemyLazerFab;
	
    public float minShootDelay = 1.0f;
    public float maxShootDelay = 7.0f;
    float nextShootTime = 0.0f;
	

	
	// Use this for initialization
	void Start () 
	{
		this.nextShootTime = Random.Range(minShootDelay, maxShootDelay)* 1f;
		

	}

	// Update is called once per frame
	void Update () 
	{
		EnemyMovement();
		
		 if (Time.time > nextShootTime)
        {
			Vector3 target = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
			Instantiate(EnemyLazerFab, target, Quaternion.identity);
            nextShootTime = (Time.time + Random.Range(minShootDelay, maxShootDelay)) * 5f;
		
        }
	
		
	}

	void OnTriggerEnter(Collider collider)
	{	

		if(collider.gameObject.CompareTag("PlayerLazer"))
		{
			Destroy(this.gameObject);
		}

		if (collider.gameObject.CompareTag("Player"))
		{
			
			Player.playerLives--;
	
		}
	}
	
	void EnemyMovement()
	{
		float t = (Time.time - startTime) * 0.4f;
        
        if (movingRight)
            x = Mathf.Lerp(leftBoundary, rightBoundary, t);
        else
            x = Mathf.Lerp(rightBoundary, leftBoundary, t);
        
        if (x > rightBoundary)
        {
            movingRight = false;
			this.startTime = Time.time;
            
        }
        else if (x < leftBoundary)
        {
            movingRight = true;
            this.startTime = Time.time;
        }
		
		else if (x == rightBoundary)
		{
			
			y= Mathf.Lerp(y,y -= 1.0f,t);
			movingRight = false;
			this.startTime = Time.time;
		}
		
		else if (x==leftBoundary)
		{
			y= Mathf.Lerp(y,y -= 1.0f,t);
			movingRight= true;
			this.startTime = Time.time;
		}
		
        this.transform.position = new Vector3(x, y, -11);

		
	}

	
}

