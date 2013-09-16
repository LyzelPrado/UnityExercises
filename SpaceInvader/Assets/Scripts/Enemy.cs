using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public static float y = -3f;
	float x = 1.0f;
	
	float startTime;
	bool movingRight = true;
	bool movingDown = false;
	

	
	
	
	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		EnemyMovement();
		
	}

	void OnTriggerEnter(Collider collider)
	{	

		if(collider.gameObject.CompareTag("Lazer"))
		{
			Destroy(this.gameObject);
		}

		/*if(collider.gameObject.CompareTag("Player"))
		{
			
			Player.playerLives--;
			y = -3f;
			Update();
	
		}*/
	}
	
	void EnemyMovement()
	{
		float t = (Time.time - startTime) * 0.4f;
        
        if (movingRight)
            x = Mathf.Lerp(1.0f, 23.0f, t);
        else
            x = Mathf.Lerp(23.0f, 1.0f, t);
        
        if (x > 23.0f)
        {
            movingRight = false;
			this.startTime = Time.time;
            
        }
        else if (x < 1.0f)
        {
            movingRight = true;
            this.startTime = Time.time;
        }
		
		else if (x == 23.0f)
		{
			movingDown = true;
			y= Mathf.Lerp(y,y -= 1.0f,t);
			movingRight = false;
			this.startTime = Time.time;
		}
		
		else if (x==1.0f)
		{
			y= Mathf.Lerp(y,y -= 1.0f,t);
			movingRight= true;
			this.startTime = Time.time;
		}
		
        this.transform.position = new Vector3(x, y, this.transform.position.z);

		
	}
}

