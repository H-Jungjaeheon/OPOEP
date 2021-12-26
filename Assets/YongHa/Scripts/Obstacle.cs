using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    int movetype;
    [SerializeField]
    float speed;

    Vector2 curpos;
    void Start()
    {
        curpos = transform.position;
    }

    void Update()
    {
        MoveLogic();

    }

    void MoveLogic()
    {
        switch (movetype)
        {
            case 1:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                if (Random.Range(0, 2) < 1)
                    transform.Translate(Vector2.left * 2 * Time.deltaTime);
                else
                    transform.Translate(Vector2.left * 2 * Time.deltaTime);
                break;
            case 3:

                break;
            default:
                break;
        }
        if (transform.position.y <= -5f)
            Destroy(gameObject);
    }

    void MoveObstacle()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (Random.Range(0, 2) < 1)
            transform.Translate(Vector2.left * 2 * Time.deltaTime);
        else
            transform.Translate(Vector2.left * 2 * Time.deltaTime);
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
