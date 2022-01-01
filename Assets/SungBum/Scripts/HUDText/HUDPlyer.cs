using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPlyer : MonoBehaviour
{
    [SerializeField]
    private Vector2[] wayPoints;
    private int wayIndex = 0;

    private void OnEnable()
    {
        StartCoroutine("OnMoveLoop");
    }

    private void OnDisable()
    {
        StopCoroutine("OnMoveLoop");
    }

    private IEnumerator OnMoveLoop()
    {
        while(true)
        {
            yield return StartCoroutine("OnMoveTo");
        }
    }

    private IEnumerator OnMoveTo()
    {
        float current = 0;
        float percent = 0;

        Vector2 start = transform.position;
        Vector2 end = wayPoints[wayIndex];

        float time = Vector2.Distance(start, end);

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;

            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }

        wayIndex = wayIndex < wayPoints.Length - 1 ? wayIndex + 1 : 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
