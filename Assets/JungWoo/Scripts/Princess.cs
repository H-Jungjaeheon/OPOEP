using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    public static int princesscount;

    void Start()
    {

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

        if (princesscount >= 30)
        {
            GameObject.Find("GameManager").GetComponent<GameMgr>().Buff1on = true;
        }
        if (princesscount >= 75)
        {
            GameObject.Find("GameManager").GetComponent<GameMgr>().Buff2on = true;
        }
        if (princesscount >= 135)
        {
            GameObject.Find("GameManager").GetComponent<GameMgr>().Buff3on = true;
        }
    }
}
