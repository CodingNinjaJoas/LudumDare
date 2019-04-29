using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	public float Strength = 2;
	private bool Damage = false;
	public void Start()
	{
		InvokeRepeating("damage", 0.5f, 0.1f);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Player")
		{
			Damage = true;
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.transform.tag == "Player")
		{
			Damage = false;
		}
	}
	public void damage()
	{
		if (Damage == true)
		{
			float f = FindObjectOfType<PlayerController>().hearts -= Strength;
			if (f >= 1)
			{
				FindObjectOfType<PlayerController>().hearts -= Strength;
				Damage = false;
			}
			else
			{
				FindObjectOfType<PlayerController>().hearts = 1;
			}


		}
	}
}
