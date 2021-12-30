using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public bool Buff1on, Buff2on, Buff3on;
    public bool Shield;
    public bool GameStart = false;
    public GameObject Princessobj;
    public GameObject StopButton;

    void Start()
    {
        InvokeRepeating("Test", 1f, 1f);
        if (Buff3on == true)
        {
            Shield = true;
        }
    }

    void Update()
    {

    }

    void Test()
    {
        GameObject a = Instantiate(Princessobj, new Vector2(Random.Range(-2, 3), GameObject.Find("Main Camera").GetComponent<Transform>().position.y), Quaternion.identity);
        if (Princess.princesscount >= 30)
        {
            a.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
        if (Princess.princesscount >= 75)
        {
            a.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
        }
        if (Princess.princesscount >= 135)
        {
            Destroy(a);
        }
    }
}
