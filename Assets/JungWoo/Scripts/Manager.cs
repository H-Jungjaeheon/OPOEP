using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool Buff1on, Buff2on, Buff3on;

    void Start()
    {
        
    }

    void Update()
    {
        if (Princess.princesscount >= 30)
        {
            Buff3on = true;
        }
        else if (Princess.princesscount >= 20)
        {
            Buff2on = true;
        }
        else if (Princess.princesscount >= 10)
        {
            Buff1on = true;
        }
    }
}
