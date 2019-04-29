using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderMoving : MonoBehaviour
{
	public bool CanMove;
	public float speed = 3;
	public Collider2D colider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (colider.IsTouching(FindObjectOfType<PlayerController>().gameObject.GetComponent<BoxCollider2D>()))
		{
			float f = FindObjectOfType<PlayerController>().hearts -= 5;
			if (f >= 1)
			{
				FindObjectOfType<PlayerController>().hearts -= 5;
				FindObjectOfType<audioManager>().PlayEffect(2);
			}

			else
			{
				FindObjectOfType<PlayerController>().hearts = 1;
				FindObjectOfType<audioManager>().PlayEffect(2);
			}
		}
	
		if (CanMove == true)
		{
			this.transform.position = this.transform.position + Vector3.right * speed * Time.deltaTime;
		}
    }
}
