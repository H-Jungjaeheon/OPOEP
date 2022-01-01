using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Warning : MonoBehaviour
{
    SpriteRenderer sprite;
    Obstacle obstacle;

    float time;

    float delay = 0.3f;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        delay = Obstacle.Warningtime;
    }


    void Update()
    {
        //transform.position = new Vector2(0, GameObject.Find("Main Camera").transform.position.y + 2f);
        
        Destroy(gameObject, delay);
        if (time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time);
            if (time > 1)
                time = 0;
        }

        time += Time.deltaTime;
    }
}
