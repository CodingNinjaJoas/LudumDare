using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFall : MonoBehaviour
{
    public float Strength = 20;
    private bool Damage = false;

    public void Start()
    {
        InvokeRepeating("damage", 0.5f, 0.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Damage = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
			Damage = true ;
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
				FindObjectOfType<audioManager>().PlayEffect(2);
				Damage = false;
			}
			else
			{
				FindObjectOfType<PlayerController>().hearts = 1;
				FindObjectOfType<audioManager>().PlayEffect(2);
			}
        }

    }
}
