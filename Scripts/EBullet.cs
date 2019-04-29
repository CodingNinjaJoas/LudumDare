using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
	[Header("Bullet System")]
	public float speed = 50f;
	public float rl = -1;//left or right going
	public string playerTag;// Tag for enemies you can hit

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
		if(collision.transform.tag == playerTag)
		{
			//damage enemy
			collision.gameObject.GetComponent<PlayerController>().Damage(1);
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
