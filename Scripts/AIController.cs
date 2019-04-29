using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
	[Header("AI References")]
	public float radius;
	public float shootRadius;
	public float walkingSpeed;
	public float jumpSpeed;
	public float jumpingReaction = 3;
	public string playerTag;

	[Header("AI Strength")]
	public float health;
	[Range(0,10)]
	public int maxDamage;

	private bool Damaging = false;
	private PlayerController player;
	private float rL;
	private bool jump = false;
	private bool Started = false;
	private Vector3 v;
	// Start is called before the first frame update
	void Start()
    {
		player = FindObjectOfType<PlayerController>();
		InvokeRepeating("DamageOponents", 1, UnityEngine.Random.Range(0, 3));
		InvokeRepeating("Jumping", 2, jumpingReaction);
    }
	public void OnCollisionStay2D(Collision2D collision)
	{
	  if(collision.gameObject.tag != playerTag)
		{
		
			StartCoroutine("Jump");
			
		}
	  
	}
	void Update()
    {

		if (Vector3.Distance(player.gameObject.transform.position, this.transform.position) <= radius)
		{
			
			this.transform.position = Vector2.MoveTowards(this.transform.position, player.gameObject.transform.position, walkingSpeed * Time.deltaTime);
			if(this.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
			{
				rL = 1;
			}
			if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
			{
				rL = -1;
			}
		}else
		{
			if (Started == false)
			{
				
				v.y = this.transform.position.y;
				v.z = this.transform.position.z;
				v.x = UnityEngine.Random.Range(-10, 10);
				Started = true;

			}
			this.transform.position = Vector2.MoveTowards(this.transform.position, v, walkingSpeed * Time.deltaTime);
		
			if (v == this.transform.position)
			{
				Started = false;
			}
		}
		if(health <= 0)
		{
			Die();
		}
		if (Vector3.Distance(player.gameObject.transform.position, this.transform.position) <= shootRadius)
		{
			Damaging = true;

		}
	}
	public void DamageOponents()
	{
		if (Damaging == true)
		{
			player.hearts -= UnityEngine.Random.Range(0, maxDamage);
			Damaging = false;
		}
	}
	public void Damage(float damage)
	{
		health -= damage;
		

	}
	public IEnumerator Jump()
	{
		
		
			

			
			
		
		
		yield return new WaitForSeconds(1f);
		jump = true;

	}
	public void Jumping()
	{
		if (jump == true) { 
		  Vector2 Force = new Vector2(0, 1 * jumpSpeed);
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(Force);
			jump = false;
	}

	}

	public void Die()
	{
		Destroy(this.gameObject);
	}
}
