using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    CapsuleCollider2D Col;

    float Sizey;

    void Start()
    {
        Sizey = Col.size.y; 
    }
    void Update()
    {
        //transform.Translate(Vector2.down * speed * Time.deltaTime);
        //if (transform.position.y <= -10)
        //    transform.position = (Vector2)transform.position + new Vector2(0, 20);
    }
    void OnBecameInvisible()
    {
        transform.position = (Vector2)transform.position + new Vector2(0, Sizey * 2);
    }
}
