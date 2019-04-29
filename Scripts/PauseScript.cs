using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
	public GameObject pause;

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pause.SetActive(!pause.active);
            FindObjectOfType<PlayerController>().walkingSpeed = 0f;
            FindObjectOfType<PlayerController>().jumpingSpeed = 0f;
            FindObjectOfType<PlayerController>().CanMove = false;
            FindObjectOfType<PlayerController>().CanJump = false;
            FindObjectOfType<PlayerController>().CanShoot = false;
        }
    }
	public void Quit()
	{
		SceneManager.LoadScene(0);
	}
    
	public void Continue()
	{
		pause.SetActive(false);
        FindObjectOfType<PlayerController>().walkingSpeed = 10f;
        FindObjectOfType<PlayerController>().jumpingSpeed = 700f;
        FindObjectOfType<PlayerController>().CanMove = true;
        FindObjectOfType<PlayerController>().CanJump = true;
        FindObjectOfType<PlayerController>().CanShoot = true;
    }

	public void ToMenu()
	{
		pause.SetActive(!pause.active);
        SceneManager.LoadScene(0);
	}
}
