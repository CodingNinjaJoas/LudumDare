using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	public bool HasBought = false;
	public List<Image> imagese = new List<Image>();
	public Text heartsT;
	public Text heartsT1;
	public GameObject instructions;

	public GameObject shop;
	public List<GameObject> IShop = new List<GameObject>();//ingame shop
	public GameObject openText;
	public PlayerController pc;
	private float f;
	private void Start()
	{

		
	
	}
	private void Update()
	{
	
			pc = FindObjectOfType<PlayerController>();
		
			foreach (GameObject item in IShop)
			{
			if (item.GetComponent<ShopIngame>().Hasbought == false)
			{
				if (Vector3.Distance(item.transform.position, pc.transform.position) <= 10)
				{
					openText.SetActive(true);
				}
				else
				{
					openText.SetActive(false);
				}
				pc = FindObjectOfType<PlayerController>();


				
				if (Input.GetKeyDown("r"))
				{
					if (Vector3.Distance(item.transform.position, pc.transform.position) <= 10)
					{
						FindObjectOfType<colliderMoving>().CanMove = !FindObjectOfType<colliderMoving>().CanMove;
						f = pc.maxHearts - 1;
						shop.SetActive(!shop.active);
						heartsT.text = f + " Hearts";
					}
				}
			}
			if (Vector3.Distance(item.transform.position, pc.transform.position) <= 10)
			{
				if (item.GetComponent<ShopIngame>().Hasbought == true)
				{
					openText.SetActive(false);
				}
			}



		}
		
		if (Input.GetKeyDown("x"))
		{
			instructions.SetActive(!instructions.active);
		}
		pc = FindObjectOfType<PlayerController>();
		f = pc.hearts - 1;
		heartsT1.text = f + " Hearts";

	}
	public void SpeedUpgrade()
	{
		pc = FindObjectOfType<PlayerController>();
		pc.hearts -= 2;
		pc.maxHearts -= 2;
		pc.walkingSpeed += 2;
		f = pc.maxHearts - 1;
		heartsT.text = f + " Hearts";
		foreach (GameObject item in IShop)
		{
			if (item.GetComponent<ShopIngame>().Hasbought == false)
			{
				if (Vector3.Distance(item.transform.position, pc.transform.position) <= 10)
				{
					item.GetComponent<ShopIngame>().Hasbought = true;
					shop.SetActive(!shop.active);
					FindObjectOfType<colliderMoving>().CanMove = !FindObjectOfType<colliderMoving>().CanMove;
				}
			}
		}
	}
	public void JumpUpgrade()
	{
		pc = FindObjectOfType<PlayerController>();
		pc.hearts -= 2;
		pc.maxHearts -= 2;
		pc.jumpingSpeed += 50;
		f = pc.maxHearts - 1;
		heartsT.text = f + " Hearts";

		foreach (GameObject item in IShop)
		{
			if (item.GetComponent<ShopIngame>().Hasbought == false)
			{
				if (Vector3.Distance(item.transform.position, pc.transform.position) <= 10)
				{
					item.GetComponent<ShopIngame>().Hasbought = true;
					shop.SetActive(!shop.active);
					FindObjectOfType<colliderMoving>().CanMove = !FindObjectOfType<colliderMoving>().CanMove;
				}
			}
		}
	}
	public void RegenerationUpgrade()
	{
		pc = FindObjectOfType<PlayerController>();
		pc.hearts -= 2;
		pc.maxHearts -= 2;
		pc.regenerationRate -= 5;
		f = pc.maxHearts - 1;
		heartsT.text = f + " Hearts";

		foreach (GameObject item in IShop)
		{
			if (item.GetComponent<ShopIngame>().Hasbought == false)
			{
				if (Vector3.Distance(item.transform.position, pc.transform.position) <= 10)
				{
					item.GetComponent<ShopIngame>().Hasbought = true;
					shop.SetActive(!shop.active);
					FindObjectOfType<colliderMoving>().CanMove = !FindObjectOfType<colliderMoving>().CanMove;
				}
			}
		}
	}
	
}
