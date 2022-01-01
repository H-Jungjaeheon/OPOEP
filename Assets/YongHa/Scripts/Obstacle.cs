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


    GameObject player;

    int MO;
    float posx;

    [Header("Warning")]
    [SerializeField]
    GameObject Warning;
    public float WarningTime;
    public static float Warningtime;

    float delay = 0.5f;

    bool Spawn = false;
    private void Awake()
    {
        Warningtime = WarningTime;
    }
    void Start()
    {
        player = GameObject.Find("KingKong");
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
            Instantiate(Warning, new Vector2(transform.position.x, GameObject.Find("Main Camera").transform.position.y + 2), Quaternion.identity);
            Spawn = true;
        }
        if (transform.position.y - player.transform.position.y <= 8 && GameObject.Find("Warning(Clone)") == null)
            transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void MoveObstacle()
    {
        float curposx = transform.position.x;
        if (GameObject.Find("GameManager").GetComponent<GameMgr>().Buff2on)
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
            if (GameObject.Find("GameManager").GetComponent<GameMgr>().Shield)
                GameObject.Find("GameManager").GetComponent<GameMgr>().Shield = false;
            else
            {
                TestPlayer temp = other.GetComponent<TestPlayer>();
                if (GameObject.Find("GameManager").GetComponent<GameMgr>().Buff1on)
                {
                    if (Random.Range(0, 101) >= 20)
                        temp.Hp--;
                }
                else
                    temp.Hp--;
            }
            Destroy(gameObject);
        }
    }

}