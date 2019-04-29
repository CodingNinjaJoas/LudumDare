using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[Header("Gun System")]
	public Transform barrelPointL;//left moving barrel point
	public Transform barrelPointR;//right moving barrel point
	public GameObject bullet;//bullet asset
	public Transform bullets;
	public float fireRate = 2;


	[Header("Walking System")]

	public float jumpingSpeed = 10;
	public string Orientation = "r";
	public Collider2D playerCollider;
	public Collider2D groundCollider2;
	public bool CanJump = true;//to prevent double jumping
	public bool CanMove = true;
	//public Collider2D playerCollider;


	[Header("Player Animation System")]
	public GameObject middle;
	public GameObject left;
	public GameObject right;
	public GameObject shootR;
	public GameObject shootL;
	public GameObject standingStillRight;
	public GameObject standingStillLeft;
	public GameObject jumpR;
	public GameObject jumpL;
	public GameObject jumpM;
	public GameObject Death;

	[Header("Health System")]
	public List<Image> images;
	public Text heartsT;
	public float hearts;
	public float maxHearts;
	public float respawnTime;

	[Header("Powerups")]
	public float bulletDamage;
	public float walkingSpeed = 10;
	public float regenerationRate = 30;
	//and the walking speed
	[Header("Respawn")]
	public Transform spawnPoint;
	public GameObject Enddoor;
	public Transform pusherPoint;
	public GameObject pusher;


	//sounds system booleans
	private bool d;
	private bool w;
	private bool j;

	private float level;
	private Rigidbody2D rb;
	private bool isShooting = false;
	public bool CanShoot;
	private bool Shoot;
	private bool startedRegeneration = false;

	void Start()
	{
		maxHearts = 6;
		Shoot = true;
		
		level = SceneManager.GetActiveScene().buildIndex;
		level -= 1;
		rb = GetComponent<Rigidbody2D>();
		while (images.Count >= hearts)
		{
			Debug.Log("While Loop Started: Image Capacity" + images.Capacity);
			images[images.Count - 1].gameObject.SetActive(false);
			images.RemoveAt(images.Count - 1);
		}
	}



	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (playerCollider.IsTouching(groundCollider2))
		{
			CanJump = true;
		}
	}


	void Update()
	{
		if (Vector3.Distance(this.transform.position, Enddoor.transform.position) < 2)
		{
			StartnextLevel();
		}

		float f = hearts - 1;
		heartsT.text = "" + f;

		if (startedRegeneration != true)
		{
			Invoke("Regenerate", regenerationRate);
			startedRegeneration = true;
		}
		//Animation Orientation
		if (isShooting == false)
		{
			if (!CanMove)
			{
				if (shootL.active == true)
				{
					shootR.SetActive(false);
					shootL.SetActive(false);
					standingStillLeft.SetActive(true);
					standingStillRight.SetActive(false);
				}
				if (shootR.active == true)
				{
					shootR.SetActive(false);
					shootL.SetActive(false);
					standingStillRight.SetActive(true);
					standingStillLeft.SetActive(false);
				}
			}
			if (Input.GetKeyDown("q") && CanJump)
			{
				right.SetActive(false);
				left.SetActive(false);
				middle.SetActive(false);
				Orientation = "l";
				shootR.SetActive(false);
				shootL.SetActive(false);
				standingStillLeft.SetActive(true);
				standingStillRight.SetActive(false);
				CanMove = false;
				CanShoot = true;
			}

			if (Input.GetKeyDown("e") && CanJump)
			{
				right.SetActive(false);
				left.SetActive(false);
				middle.SetActive(false);
				shootR.SetActive(false);
				shootL.SetActive(false);
				standingStillLeft.SetActive(false);
				standingStillRight.SetActive(true);
				Orientation = "r";
				CanMove = false;
				CanShoot = true;
			}

			if (CanMove)
			{
				if (!Input.GetKey("d") && !Input.GetKey("a"))
				{

					Orientation = "m";

				}
				if (Orientation == "r" && CanJump && !Input.GetKey("e"))
				{
					right.SetActive(true);
					left.SetActive(false);
					middle.SetActive(false);
					shootR.SetActive(false);
					shootL.SetActive(false);
					standingStillLeft.SetActive(false);
					standingStillRight.SetActive(false);
					jumpM.SetActive(false);
					jumpR.SetActive(false);
					jumpL.SetActive(false);
					Shoot = true;
					CanShoot = true;
				}
				else
				{
					right.SetActive(false);
					CanShoot = false;
				}

				if (Orientation == "l" && CanJump && !Input.GetKey("q"))
				{
					right.SetActive(false);
					left.SetActive(true);
					middle.SetActive(false);
					shootR.SetActive(false);
					shootL.SetActive(false);
					standingStillLeft.SetActive(false);
					standingStillRight.SetActive(false);
					jumpM.SetActive(false);
					jumpR.SetActive(false);
					jumpL.SetActive(false);
					Shoot = true;
					CanShoot = true;
				
				}
				else
				{
					left.SetActive(false);
					CanShoot = false;
				}

				if (Orientation == "m" && CanJump)
				{
					right.SetActive(false);
					left.SetActive(false);
					middle.SetActive(true);
					shootR.SetActive(false);
					shootL.SetActive(false);
					standingStillLeft.SetActive(false);
					standingStillRight.SetActive(false);
					jumpM.SetActive(false);
					jumpR.SetActive(false);
					jumpL.SetActive(false);
				}
				else if (!Input.GetKey("a") && !Input.GetKey("d"))
				{
					middle.SetActive(false);
					jumpM.SetActive(true);
					right.SetActive(false);
					left.SetActive(false);
					JumpingSound();
				}
			}

			if (!CanJump && Input.GetKey("a"))
			{
				right.SetActive(false);
				left.SetActive(false);
				middle.SetActive(false);
				shootR.SetActive(false);
				shootL.SetActive(false);
				standingStillLeft.SetActive(false);
				standingStillRight.SetActive(false);
				jumpR.SetActive(false);
				jumpL.SetActive(true);
				jumpM.SetActive(false);
				JumpingSound();
				Orientation = "l";
			}
			else
			{
				jumpL.SetActive(false);
			}

			if (!CanJump && Input.GetKey("d"))
			{
				right.SetActive(false);
				left.SetActive(false);
				middle.SetActive(false);
				shootR.SetActive(false);
				shootL.SetActive(false);
				standingStillLeft.SetActive(false);
				standingStillRight.SetActive(false);
				jumpR.SetActive(true);
				jumpL.SetActive(false);
				jumpM.SetActive(false);
				JumpingSound();
				Orientation = "r";
			}
			else
			{
				jumpR.SetActive(false);
			}

		}
		if (hearts <= 1)
		{
			hearts = 1;
		}
		while (images.Count < hearts - 1)
		{
			FindObjectOfType<Shop>().imagese[images.Count].gameObject.SetActive(true);
			images.Add(FindObjectOfType<Shop>().imagese[images.Count]);
		}
		while (images.Count >= hearts)
		{
			images[images.Count - 1].gameObject.SetActive(false);
			images.RemoveAt(images.Count - 1);
		}
		if (hearts == 2)
		{
			if (images.Capacity == 2)
			{
				images[0].gameObject.SetActive(false);
				images.RemoveAt(1);
			}
		}
		if (hearts <= 1)
		{
			Die();
		}
		//Walking system


		if (Input.GetKey("d"))
		{

			Invoke("WalkingSound", 0.1f);
			Vector3 Movement = new Vector3(1 * walkingSpeed, 0, 0);
			transform.position = transform.position + Movement * Time.deltaTime;
			//Vector2 Force = new Vector2(1 * walkingSpeed,0);
			//rb.AddForce(Force);
			Orientation = "r";
			CanMove = true;
			CanShoot = false;
		}

		if (Input.GetKey("a"))
		{

			Invoke("WalkingSound", 0.1f);
			Vector3 Movement = new Vector3(-1 * walkingSpeed, 0, 0);
			transform.position = transform.position + Movement * Time.deltaTime;
			//Vector2 Force = new Vector2(-1 * walkingSpeed, 0);		
			//rb.AddForce(Force);
			Orientation = "l";
			CanMove = true;
		}
		if (Input.GetKeyDown("w")) //&& !Input.GetKey("a") && !Input.GetKey("d")
		{
			if (CanJump == true)
			{
				Invoke("JumpingSound", 0.1f);
				//Vector3 Movement = new Vector3(0, 1 * jumpingSpeed, 0);
				//transform.position = transform.position + Movement * Time.deltaTime;
				CanJump = false;
				Vector2 Force = new Vector2(0, 1 * jumpingSpeed);
				rb.AddForce(Force);
				Orientation = "m";
			}

		}
	}

	public void StartnextLevel()
	{
		if (PlayerPrefs.GetFloat("" + level) == 0)
		{

			PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
			PlayerPrefs.SetFloat("" + level, 1);
		}
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (Orientation == "r" && CanJump && CanShoot)
			{
				StartCoroutine("ShootR");
			}
			if (Orientation == "l" && CanJump && CanShoot)
			{
				StartCoroutine("ShootL");
			}
		}
	}
	public void Regenerate()
	{
		if (hearts < maxHearts)
		{
			hearts += 1;
			FindObjectOfType<Shop>().imagese[images.Count].gameObject.SetActive(true);
			images.Add(FindObjectOfType<Shop>().imagese[images.Count]);

			startedRegeneration = false;
		}
	}

	public IEnumerator ShootR() { 
	if(Shoot == true){
		Shoot = false;
		isShooting = true;
		CanShoot = false;
		Invoke("CanFire", fireRate);
	right.SetActive(false);
		left.SetActive(false);
		middle.SetActive(false);
		shootR.SetActive(true);
		shootL.SetActive(false);
		standingStillRight.SetActive(false);
		standingStillLeft.SetActive(false);
		
		yield return new WaitForSeconds(0.5f);
	FindObjectOfType<audioManager>().PlayEffect(2);
	GameObject b = Instantiate(bullet, barrelPointR.transform);
	b.transform.SetParent(bullets);
		b.transform.position = barrelPointR.transform.position;
		b.GetComponent<Bullet>().rl = 1;
		b.GetComponent<Bullet>().damage = bulletDamage;
		isShooting = false;
			CanShoot = true;

		}

	}
	public void CanFire()
	{

		Shoot = true;
	}
	public IEnumerator ShootL()
	{
		if (Shoot == true)
		{
			Shoot = false;
			CanShoot = false;
			isShooting = true;
			right.SetActive(false);
			left.SetActive(false);
			middle.SetActive(false);
			shootR.SetActive(false);
			shootL.SetActive(true);
			standingStillRight.SetActive(false);
			standingStillLeft.SetActive(false);
			Invoke("CanFire", fireRate);
			yield return new WaitForSeconds(0.5f);
			FindObjectOfType<audioManager>().PlayEffect(2);
			GameObject b = Instantiate(bullet, barrelPointL.transform);
			b.transform.SetParent(bullets);
			b.transform.position = barrelPointL.transform.position;
			b.GetComponent<Bullet>().rl = -1;
			b.GetComponent<Bullet>().damage = bulletDamage;
			isShooting = false;
			CanShoot = true;
		}
	}
	public void Damage(float damage)
	{
		hearts -= damage;
		FindObjectOfType<audioManager>().PlayEffect(2);
	}

	public void Die()
	{
		Debug.Log("Oops, you died.... ");
		Invoke("PlayDeath",0.1f);
		middle.SetActive(false);
		left.SetActive(false);
		right.SetActive(false);
		shootR.SetActive(false);
		shootL.SetActive(false);
		standingStillRight.SetActive(false);
		standingStillLeft.SetActive(false);
		jumpR.SetActive(false);
		jumpL.SetActive(false);
		jumpM.SetActive(false);
		Death.SetActive(true);
		CanJump = false;
		CanMove = false;
		CanShoot = false;

		Invoke("Respawn", respawnTime);
	}
	public void PlayDeath()
	{
		
		if (d == false)
		{
			FindObjectOfType<audioManager>().PlayEffect(3);
			d = true;
		}
		Invoke("PlayDeathTrue",1);
	}
	public void PlayDeathTrue()
	{
		d = false;
	}
	public void WalkingSound()
	{
		if(w == false)
		{
			FindObjectOfType<audioManager>().PlayEffect(0);
			w = true;
		}
		Invoke("PlayWalkingTrue", 0.2f);
	}
	public void PlayWalkingTrue()
	{
		w = false;
	}
	public void JumpingSound()
	{
		if (j == false)
		{
			FindObjectOfType<audioManager>().PlayEffect(0);
			j = true;
		}
		Invoke("PlayJumpingTrue", 0.5f);
	}
	public void PlayJumpingTrue()
	{
		j = false;
	}

	public void Respawn()
	{
		this.transform.position = spawnPoint.position;
		pusher.transform.position = pusherPoint.position;
		hearts = 6;
		Death.SetActive(false);
		middle.SetActive(true);
	}
	
}

