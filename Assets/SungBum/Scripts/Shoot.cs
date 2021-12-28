using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public LineCtrl LC;

    Vector2 PlayerPos;
    Vector2 MovePlayerPos;

    Camera cam;
    Vector2 startPoint;
    Vector2 endPoint;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        LC = GetComponent<LineCtrl>();

        PlayerPos = transform.position;
        MovePlayerPos = PlayerPos;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = transform.position;

        if (0.1f < Vector3.Distance(PlayerPos, MovePlayerPos))
            this.gameObject.transform.position = Vector3.Lerp(PlayerPos, MovePlayerPos, 5f * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            LC.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);

            MovePlayerPos = PlayerPos + (startPoint - endPoint);

            LC.EndLine();
        }
    }
}
