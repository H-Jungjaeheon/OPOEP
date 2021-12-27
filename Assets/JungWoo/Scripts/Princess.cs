using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    public static int princesscount;
    public GameObject Princessobj;

    void Start()
    {
        //Instantiate(Princessobj, new Vector2(Random.Range(-2, 3), 1), Quaternion.identity);
        Invoke("Test", 1f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            princesscount += 1;
            Destroy(this.gameObject);
        }
    }

    void Test()
    {
        Instantiate(Princessobj, new Vector2(Random.Range(-2, 3), GameObject.Find("Main Camera").GetComponent<Transform>().position.y), Quaternion.identity);
    }
}
