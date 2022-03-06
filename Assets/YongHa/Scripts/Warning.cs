using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Warning : MonoBehaviour
{
    SpriteRenderer sprite;

    float time;

    public float delay;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = new Vector2(0, Camera.main.transform.position.y + 1f);

        Destroy(gameObject, delay);
    }
    public void Setani()
    {
    }
}
