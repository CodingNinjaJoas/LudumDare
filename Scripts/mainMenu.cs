using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{

	public void Update()
	{
		
		if (PlayerPrefs.GetInt("Opened4") == 0)
		{
			Debug.Log("Started first time");
			PlayerPrefs.SetInt("Level", 1);
			PlayerPrefs.SetInt("Opened4", 1);
	}

	}
	public void Quit()
	{
        Application.Quit();
	}
	public void Play(float level)
	{	
		if (PlayerPrefs.GetInt("Level") >= level)
		{
			SceneManager.LoadScene("" + level);
		}
	}
}
