using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ManagerMenu : MonoBehaviour
{
	
	public GameObject menu;// get from "Canvas" panel "Menu"
	private bool gameScale = false; //activation check, initially disabled
	public AudioMixerGroup Mixer; //Get music mixer
	
	
	void Start()
	{
		menu.GetComponentInChildren<Toggle>().isOn =  PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
		menu.GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("MusicMaster", 1);
	}
	
    void Update()
    {
        if (Input.GetKeyDown("escape"))//gameScale = false - gameprocess is active, if press Esc - gameScale - stop gameprocess and active "Menu", and reverse actions when pressed  
			{
				if (gameScale)
				{
					Resumed();
				}			
				else
				{
					
					Pause();
						
				}
			}
	
    }
	
	public void Resumed()
	{
		
		menu.SetActive(false);//"menu" isn't active 
		Time.timeScale = 1f;//gameplay active
		gameScale = false;
	
	}
	
	void Pause()
	{
		
		menu.SetActive(true);//"menu" is active 
		Time.timeScale = 0f;//gameplay isn't active
		gameScale = true;
	
	}
	
	 public void Exit()
	{
		Application.Quit();// Exit game 
	}
	
	public void ToggleMusic(bool enabled)//Toggle off\on background music
	{	
			// if checkbox - on(enabled), then music in mixer gets value = 0 and music playing
		if(enabled){
			
		Mixer.audioMixer.SetFloat("Music",0); // on music background	
		
		}
		else{
			
		Mixer.audioMixer.SetFloat("Music",-80); //off music background
			
		}
			
		PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
			
	}
	
	public void ChangeVolume(float volume) 
	{	//MasterVolume get all audio effect(background music, jump effect), Mathf.Lerp gets an intermediate value between -80,0
		//the value obtained in the interval is written to the variable -- volume 
		Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
		
		PlayerPrefs.SetFloat("MusicMaster", volume);
	}
}
