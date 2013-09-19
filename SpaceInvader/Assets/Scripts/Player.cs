using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float playerSpeed = 1000.0f;
	public static int playerLives=3;
	public static int score = 0;
	public static float timer = 0f;
	bool isTouch = true;

	// reference prefabs
	public GameObject Lazer;
	

	// Use this for initialization
	void Start () {
		
	
		transform.position = new Vector3(0, 0, 0);


	}

	// Update is called once per frame
	void Update () {

		//move the player left to right
		
		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x;
		dir.y = 0;
		dir.z = 0;
			
		if (dir.sqrMagnitude > 1)
				dir.Normalize();
		
		dir *= Time.deltaTime;
		transform.Translate(dir*playerSpeed);

		// if the player object is positioned at x=15 then it will appear at x= -15 and vice versa

		if(transform.position.x > 15)
			transform.position = new Vector3(-15,transform.position.y, transform.position.z );

		else if (transform.position.x < -15)
			transform.position = new Vector3(15,transform.position.y, transform.position.z );

		//touch screen to fire a laser
		
		if(isTouch)
		{
			foreach(Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Began)
				{
					Vector3 projectPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
					Instantiate(Lazer, projectPos, Quaternion.identity);
	
				}
			}
		}

		

		if(Time.time - timer > 1)
		{
			renderer.enabled=true;
			isTouch=true;
			collider.enabled=true;
		}
	}
	
	
	
	//when player hit enemy, enemy will destroy
	

	void OnTriggerEnter(Collider collide)
	{
		if(collide.gameObject.CompareTag("Enemy") || collide.gameObject.CompareTag("Bullet") )
		{
			playerLives--;
			renderer.enabled=false;
			isTouch=false;
			collider.enabled=false;
			timer=Time.time;
		}
			
		
		if(playerLives == 0)
		{
			DestroyObject(this.gameObject);
			Application.LoadLevel(2);
		}
	}

}