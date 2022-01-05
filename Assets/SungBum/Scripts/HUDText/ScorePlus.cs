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

    public List<int> Score = new List<int>();

    public void SpawnHUDText(string text1, string text2, Color color)
    {
        GameObject clone = Instantiate(hudTextPrefab);

        clone.transform.SetParent(parentTransform);
        Bounds bounds = GetComponent<Collider2D>().bounds;
        clone.GetComponent<ComboCtrl>().Play(text1, text2, color, bounds);
    }

    protected virtual void AddScore(int ComScore)
    {
        Score.Add(ComScore);
        InGameMgr.PScore += ComScore;
    }

    public void DelScore(int ComScore)
    {
        Score.Remove(ComScore);
    }
}
