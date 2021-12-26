using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField]
    int speed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y <= -10)
            transform.position = (Vector2)transform.position + new Vector2(0, 20);
    }
}
