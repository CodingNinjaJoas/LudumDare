using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAI : MonoBehaviour
{

	public float delta = 1.5f;  // Amount to move left and right from the start point
	public float speed = 2.0f;
	public float damage = 1f;
	public float damageSpeed = 0.2f;
	private Vector3 startPos;
	private bool IsHitting = false;
	public float health = 2;
	void Start()
	{
		startPos = transform.position;
	}
	private void OnCollisionStay2D(Collision2D collision)
	{
		if (IsHitting == false)
		{
			if (collision.transform.tag == "Player")
			{
				StartCoroutine("Damage");
				IsHitting = true;
			}
		}
		
	}
	void Update()
	{
		if (health <= 0)
		{
			Destroy(this.gameObject);
		}
		Vector3 v = startPos;
		v.x += delta * Mathf.Sin(Time.time * speed);
		transform.position = v;
	}
	public IEnumerator Damage()
	{
		FindObjectOfType<PlayerController>().Damage(damage);
		yield return new WaitForSeconds(damageSpeed);
		IsHitting = false;
	}
}

