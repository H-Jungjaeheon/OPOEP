using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Obstacles = new List<GameObject>();
    float[] pos = new float[3] { 1.5f, 0, 1.5f };

    [SerializeField]
    float SpawnDelay = 3;
    float SpawnCur = 0;

    [SerializeField]
    bool Test;

    void Start()
    {

    }

    void Update()
    {
        Spawn();
        TestSpawn();
    }
    void TestSpawn()
    {
        if (Test)
        {
            if (Input.GetKeyDown(KeyCode.O))
                Instantiate(Obstacles[0], new Vector2(0, 3), Quaternion.identity);
            if (Input.GetKeyDown(KeyCode.M))
                Instantiate(Obstacles[1], new Vector2(0, 3), Quaternion.identity);
            if (Input.GetKeyDown(KeyCode.F))
                Instantiate(Obstacles[2], new Vector2(0, 3), Quaternion.identity);
        }
    }
    void Spawn()
    {
        SpawnCur += Time.deltaTime;
        if (SpawnCur >= SpawnDelay)
        {
            Instantiate(Obstacles[Random.Range(0, 3)], new Vector2(pos[Random.Range(0, 3)], 3),
                Quaternion.identity, this.transform);
            SpawnCur = 0;
        }

    }
}
