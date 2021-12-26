using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DWTest : MonoBehaviour
{
    [SerializeField] Image Background;
    [SerializeField] Image BackgroundBlack;
    void Start()
    {
        Background.transform.DOScale(0, 0).SetEase(Ease.OutBack);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnButtonClick()
    {     
        Background.transform.DOScale(1, 1).SetEase(Ease.OutBack);
    }
    public void OnExitButtonClick()
    {
        Background.transform.DOScale(0, 0.7f).SetEase(Ease.InBack);
    }
    public void OnButtonClickBlack()
    {
        BackgroundBlack.transform.DOMove(new Vector3(550,1000,0), 0.4f);
    }
    public void OnExitButtonClickBlack()
    {
        BackgroundBlack.transform.DOMove(new Vector3(-1090, 1000, 0), 0.8f).SetEase(Ease.InBack);
    }
}
