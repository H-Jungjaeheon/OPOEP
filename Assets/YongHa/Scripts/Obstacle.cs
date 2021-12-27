using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    int movetype;
    [SerializeField]
    float speed;
    public bool dir = false;

    SpriteRenderer sprite;
    CapsuleCollider2D col;

    Vector2 curpos;
    float posx;
    int MO;

    void Start()
    {
        col = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        curpos = transform.position;
    }

    void Update()
    {
        posx = transform.position.x;
        switch (movetype)
        {
            case 1:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
            case 2:
                MoveObstacle();
                break;
            case 3:
                break;
            default:
                break;
        }
    }

    void MoveObstacle()
    {
        print(posx);
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (posx <= -2f && !dir)
        {
            transform.Rotate(new Vector2(0, -180));
            dir = true;
        }
        else if (posx >= 0f && dir)
        {
            transform.Rotate(new Vector2(0,180));
            dir = false;
        }

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TestPlayer temp = other.GetComponent<TestPlayer>();
            temp.Hp--;
            Destroy(this.gameObject);
        }
    }

}
