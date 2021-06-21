using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CAMERAFOLLOW : MonoBehaviour
{

	public Transform KusyaPos;
	public Text score;
	private int plus = 0;
	
    void Update()
    {	
        if (KusyaPos.position.y > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, KusyaPos.position.y, transform.position.z);
			Score();
		}
    }
	
	void Score(){
		
		plus ++;
		score.text = "Score: " + plus;
	
	}
}
   