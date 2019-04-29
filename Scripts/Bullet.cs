using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[Header("Bullet System")]
	public float speed = 50f;
	public float damage = 1;
	public float rl = -1;//left or right going
	public string enemyTag;// Tag for enemies you can hit

	[Header("Bullet Orientation Objects")]
	public GameObject left;
	public GameObject right;
	public void Start()
	{
		if(rl == 1)
		{
			right.SetActive(true);
			left.SetActive(false);
			
		}
		if (rl == -1)
		{
			right.SetActive(false);
			left.SetActive(true);
		}
		speed *= rl;
	}
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.tag == enemyTag)
		{
			//damage enemy
			collision.gameObject.GetComponent<MovingAI>().health -= damage;
		
			Destroy(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
	void FixedUpdate()
    {
		
		Vector3 position = this.transform.position;
		position.x += speed;
		this.transform.position = position;
	}
}
