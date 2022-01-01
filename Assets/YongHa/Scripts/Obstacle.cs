using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    int movetype;
    [SerializeField]
    float speed;
    [SerializeField]
    bool dir = false;
    [SerializeField]
    float Setdistance = 0.5f;

    [SerializeField]
    GameObject player;

    int MO;
    float posx;

    [SerializeField]
    GameObject Warning;
    GameObject Camera;

    public float delay = 0.5f;

    bool Spawn = false;
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        player = GameObject.Find("KingKong");
        posx = transform.position.x;


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
            Instantiate(Warning, new Vector2(transform.position.x, Camera.transform.position.y + 2), Quaternion.identity);
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
            if (GameObject.Find("GameManager").GetComponent<GameMgr>().Shield == true)
            {
                GameObject.Find("GameManager").GetComponent<GameMgr>().Shield = false;
            }
            else
            {
                if (GameObject.Find("GameManager").GetComponent<GameMgr>().Buff1on == true)
                {
                    if (Random.Range(0, 101) >= 20)
                    {
                        TestPlayer temp = other.GetComponent<TestPlayer>();
                        temp.Hp--;
                    }
                }
                else
                {
                    TestPlayer temp = other.GetComponent<TestPlayer>();
                    temp.Hp--;
                }
            }
            Destroy(this.gameObject);
        }
    }

}