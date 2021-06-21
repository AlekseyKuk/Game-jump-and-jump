using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Platform : MonoBehaviour
{
	
	
	public float forceJump;
	AudioSource JumpEffect;

	void Start(){
		
		JumpEffect = GetComponent<AudioSource>();
		
	}
	
	void Update()
	{
	}

	
    public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y < 0){
			
				JumpEffect.Play();
				Kusya.instance.rigidKysya.velocity = Vector2.up * forceJump;

		}	
	}
	
	public void OnCollisionExit2D(Collision2D collision)
	{		
		
		if(collision.collider.name == "DeadZone")
		{
			float RandX = Random.Range(-5f,5f);
			float RandY = Random.Range(transform.position.y + 10f, transform.position.y + 15f );
			
			transform.position = new Vector3(RandX, RandY, 0);
			
		}
		
		
	}
	
}