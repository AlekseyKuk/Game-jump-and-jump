using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Kusya : MonoBehaviour
{	
	
	public static Kusya instance;//for script "Platform" gets Rigidbody2D 
	public Rigidbody2D rigidKysya;
	private int vertical;//to check rotation
	public float speed = 3.7f;


		
    void Start()
    {	
		
		if(instance == null)
		{
			instance = this;
		}
    }


    void FixedUpdate()
    {
		
		
		float transform1 = Input.GetAxis("Horizontal") * speed * Time.deltaTime;//Controller 
		transform.Translate(transform1, 0,0);//move on axis X
		vertical = 0;
		RotatePlayerSkin();
	
	}
	
	 public void OnCollisionEnter2D(Collision2D collision){
			
		if (collision.collider.name == "DeadZone")
		{
			SceneManager.LoadScene(0);
		}
				
	 }
	 
	 void RotatePlayerSkin(){
		 
		 if (Input.GetKey(KeyCode.A) ^ Input.GetKey("left")){
		   
			vertical += 1;
			
		}
		
		if (Input.GetKey(KeyCode.D) ^ Input.GetKey("right") ){
			
			vertical -= 1;
		}
		
		if(vertical == 1){
			
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}
		
		if(vertical == -1){
			
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
		}
		 
	 }
	  
}