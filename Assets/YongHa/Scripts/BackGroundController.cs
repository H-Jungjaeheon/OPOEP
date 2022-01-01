using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    CapsuleCollider2D Col;

    float Sizey;

    void Start()
    {
        Col = GetComponent<CapsuleCollider2D>();
        Sizey = Col.size.y; 
    }
    void Update()
    {
        
    }
    void OnBecameInvisible()
    {
        transform.position = (Vector2)transform.position + new Vector2(0, Sizey * 2);
    }
}
