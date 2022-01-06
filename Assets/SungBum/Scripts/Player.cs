using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Shoot shoot;

    private void Awake()
    {
        shoot = this.gameObject.GetComponent<Shoot>();
    }
    // Start is called before the first frame update
    void Start()
    {  
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);

        if (worldpos.x < 0.13f)
        {
            worldpos.x = 0.13f;
            shoot.MovePlayerPos = transform.position;
        }
        if (worldpos.x > 1f - 0.13f)
        {
            worldpos.x = 1f - 0.13f;
            shoot.MovePlayerPos = transform.position;
        }
        if (worldpos.y > 1f - 0.05f)
        {
            worldpos.y = 1f - 0.05f;
            shoot.MovePlayerPos = transform.position;
        }

        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);
    }
}
