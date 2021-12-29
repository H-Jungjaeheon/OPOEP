using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0.0f, 1.0f * Time.deltaTime, 0.0f);
    }
}
