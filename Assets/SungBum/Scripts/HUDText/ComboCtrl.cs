using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCtrl : MonoBehaviour
{
    [SerializeField]
    private float moveDistance = 100;
    [SerializeField]
    private float moveTime = 1.5f;

    private RectTransform rectTransform;
    private TextMeshProUGUI textHud;

    public GameObject Kong;

    int comScore = 0;

    private void OnDisable()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textHud = GetComponent<TextMeshProUGUI>();
        Kong = GameObject.Find("KingKong");
    }

    public void Play(string text1, string text2, Color color, Bounds bounds, float gap=0.1f)
    {
        comScore = int.Parse(text1);

        textHud.text = text1 + text2;
        textHud.color = color;

        Debug.Log(comScore);
        StartCoroutine(onHUDText(bounds, gap));
    }

    IEnumerator onHUDText(Bounds bounds, float gap)
    {
        Vector2 start = Camera.main.WorldToScreenPoint(new Vector3(bounds.center.x, bounds.max.y + gap, bounds.center.z));
        Vector2 end = start + Vector2.up * moveDistance;

        float current = 0;
        float percent = 0;
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            rectTransform.position = Vector2.Lerp(start, end, percent);

            Color color = textHud.color;
            color.a = Mathf.Lerp(1, 0, percent);
            textHud.color = color;

            yield return null;
        }

        Kong.GetComponent<Shoot>().DelScore(comScore);
        Destroy(gameObject);
    }
}
