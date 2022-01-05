using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlus : MonoBehaviour
{
    [SerializeField]
    private Transform parentTransform;
    [SerializeField]
    private GameObject hudTextPrefab;

    private Vector2 startPosition;
    private Vector2 endPosition;

    public void SpawnHUDText(string text, Color color)
    {
        GameObject clone = Instantiate(hudTextPrefab);

        clone.transform.SetParent(parentTransform);
        Bounds bounds = GetComponent<Collider2D>().bounds;
        clone.GetComponent<ComboCtrl>().Play(text, color, bounds);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }

        if (Input.GetMouseButton(0))
        {
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            SpawnHUDText("1000", Color.red);
        }
    }
}
