using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatform : MonoBehaviour
{
	
	public GameObject platforms;
	
    
    void Start()
    {
        Vector2 SpawnerPosition = new Vector2();
		
		for (int i = 0; i < 10; i++)
		{
			SpawnerPosition.x = Random.Range(-5f,5f);
			SpawnerPosition.y = Random.Range(0f,10f);
			
			Instantiate(platforms, SpawnerPosition, Quaternion.identity);
		}
    }

   
}
