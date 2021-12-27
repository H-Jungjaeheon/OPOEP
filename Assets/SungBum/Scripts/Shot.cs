using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    public LineCtrl LC;

    Camera cam;
    public Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    float currentY;
    float BeforeY;

    bool ShotChk = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        LC = GetComponent<LineCtrl>();
        rb.gravityScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        BeforeY = transform.position.y;

        if (BeforeY < currentY && ShotChk == true)
        {
            rb.gravityScale = 0.0f;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        currentY = transform.position.y;

        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            ShotChk = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            LC.RenderLine(startPoint, currentPoint);
        }

        if(Input.GetMouseButtonUp(0))
        {
            rb.gravityScale = 2.0f;
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x),
                Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));

            rb.AddForce(force * power, ForceMode2D.Impulse);
            LC.EndLine();
            ShotChk = true;
        }
    }
}