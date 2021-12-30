using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public bool Buff1on, Buff2on, Buff3on;
    public bool Shield;
    void Start()
    {
        if (Buff3on == true)
        {
            Shield = true;
        }
    }

    void Update()
    {

    }
}
