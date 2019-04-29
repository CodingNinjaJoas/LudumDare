using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingObject : MonoBehaviour
{
	public GameObject breakingObj1;
	public GameObject breakingObj2;
	public GameObject breakingObj3;
	// Start is called before the first frame update
	void Start()
    {
        
    }
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.transform.tag == "Player")
		{
			StartCoroutine("Destroy");
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
	public IEnumerator Destroy()
	{
		breakingObj1.SetActive(false);
		breakingObj2.SetActive(true);
		breakingObj3.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		breakingObj1.SetActive(false);
		breakingObj2.SetActive(false);
		breakingObj3.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		Destroy(this.gameObject);
	}
}
