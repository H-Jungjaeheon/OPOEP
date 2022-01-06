using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("장애물 설정")]
    [SerializeField]
    int movetype;
    [SerializeField]
    float speed;

    [SerializeField]
    float Setdistance = 0.5f;
    bool dir = false;

    GameMgr GM;
    GameObject player;

    int MO;
    float posx;

    [Header("Warning")]
    public GameObject Warning;
    public float WarningTime;

    float delay = 0.5f;

    bool Spawn = false;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        //player = GameObject.FindGameObjectWithTag("Player");
        GM = FindObjectOfType<GameMgr>();
    }
    void Start()
    {
        posx = transform.position.x;
        MO = Random.Range(0, 2);
    }

    void Update()
    {
        switch (movetype)
        {
            case 1:
                break;
            case 2:
                MoveObstacle();
                break;
            case 3:
                FallObstacle();
                break;
            default:
                break;
        }
    }
    public void FallObstacle()
    {

        if (transform.position.y - player.transform.position.y <= 10 && !Spawn)
        {
            GameObject warning = Instantiate(Warning, new Vector2(transform.position.x, GameObject.FindGameObjectWithTag("MainCamera").transform.position.y + 2), Quaternion.identity);
            warning.GetComponent<Warning>().delay = WarningTime;
            Spawn = true;
        }
        if (transform.position.y - player.transform.position.y <= 8 && Spawn)
            transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void MoveObstacle()
    {
        float curposx = transform.position.x;
        if (GM.Buff2on)
            speed *= 0.8f;
        if (MO == 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (posx - Setdistance >= curposx && !dir)
            {
                transform.Rotate(new Vector2(0, -180));
                dir = true;
            }
            else if (posx + Setdistance <= curposx && dir)
            {
                transform.Rotate(new Vector2(0, 180));
                dir = false;
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (posx + Setdistance <= curposx && !dir)
            {
                transform.Rotate(new Vector2(0, -180));
                dir = true;
            }
            else if (posx - Setdistance >= curposx && dir)
            {
                transform.Rotate(new Vector2(0, 180));
                dir = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GM.Shield)
                GM.Shield = false;
            else
            {
                if (GM.Buff1on)
                {
                    //if (Random.Range(0, 101) >= 20)
                    //{

                    //}

                }
                else
                {

                }

            }

        }
    }

}