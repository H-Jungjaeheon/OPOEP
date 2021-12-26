using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public int Hp = 3;
    [SerializeField]
    float speed;
    void Start()
    {

    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right*speed*Time.deltaTime);
    }
}
