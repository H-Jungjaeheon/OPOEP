using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public bool IsGa
    public bool Buff1on, Buff2on, Buff3on;
    public bool Shield;
    public bool GameStart = false;
    public GameObject Princessobj;
    public GameObject StopButton;
    public int SpawnInterval;
    private Vector2 PrevLoc = new Vector2(0, 0);
    public int Require1, Require2, Require3;
    public Slider PrincessGauge;

    void Start()
    {
        if (Buff3on == true)
        {
            Shield = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Princess.princesscount += 1;
        }
        if (PrevLoc.y + SpawnInterval <= GameObject.Find("KingKong").gameObject.transform.position.y)
        {
            PrevLoc = GameObject.Find("KingKong").gameObject.transform.position;
            SpawnPrincess();
        }
        PrincessGauge.value = Princess.princesscount;
    }

    void SpawnPrincess()
    {
        if (Princess.princesscount < Require3)
        {
            GameObject a = Instantiate(Princessobj, new Vector2(Random.Range(-2, 3), GameObject.Find("Main Camera").GetComponent<Transform>().position.y), Quaternion.identity);
            if (Princess.princesscount >= Require1)
            {
                a.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            }
            if (Princess.princesscount >= Require2)
            {
                a.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
            }
        }
    }
}
