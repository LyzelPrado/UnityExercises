using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public int playerSpeed = 5;
	public static int playerLives=3;
	public static int score = 0;
	float timer = 0f;
	
	// reference prefab
	public GameObject Lazer;
	GameObject Enemy;
	
	
	// Use this for initialization
	void Start () {
		//spawn point
		// position the player
		transform.position = new Vector3(0, -7, 7);
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//move the player left to right
		transform.Translate(Vector3.right * playerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
		
		
		// if the player object is positioned at x=17 then it will appear at x= -17 and vice versa
		
		if(transform.position.x > 17)
			transform.position = new Vector3(-17,transform.position.y, transform.position.z );
	
		else if (transform.position.x < -17)
			transform.position = new Vector3(17,transform.position.y, transform.position.z );

		//press space bar to fire a laser
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 projectPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
			Instantiate(Lazer, projectPos, Quaternion.identity);
			
		}
		
		if(Time.time - timer > 1)
			renderer.enabled=true;
		
		
		
	
	}
	
	void OnTriggerEnter(Collider collide)
	{
		if(collide.gameObject.CompareTag("Enemy"))
		{
			
			playerLives--;
			renderer.enabled=false;
			timer=Time.time;
			
			if(playerLives == 0)
			DestroyObject(this.gameObject);
		}
	}
	
}
