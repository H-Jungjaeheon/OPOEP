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
        transform.position = new Vector2(0, GameObject.Find("Main Camera").transform.position.y + 1f);

        Destroy(gameObject, delay);
        if (time < 0.5f)
        {
            sprite.color = new Color(1, 1, 1, 1 - time * 0.8f);
        }
        else
        {
            sprite.color = new Color(1, 1, 1, time);
            if (time > 1)
                time = 0;
        }

        time += Time.deltaTime;
    }
}
