using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
	public static int princesscount;
	void Start()
	{
		Random.Range(0, 10);
	}

	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("1");
		if (collision.tag == "Player")
		{
			princesscount += 1;
			Destroy(this.gameObject);
		}
	}
}
