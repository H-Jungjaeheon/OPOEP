using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    int movetype;
    [SerializeField]
    float speed;

    void Start()
    {

    }

    void Update()
    {

    }

    private void Move()
    {
        switch (movetype)
        {
            case 1:
                break;
            case 2:
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
            case 3:
                break;
            default:
                break;

        }

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
    IEnumerator FallObstacle()
    {

        yield return new WaitForSeconds(1f);
    }
}
