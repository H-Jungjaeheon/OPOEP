using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class DWTest : MonoBehaviour
{
    [SerializeField] Image Background;
    [SerializeField] Image BackgroundBlack;
    [SerializeField] Image GameStart;
    [SerializeField] Image Shop;
    [SerializeField] Image Setting;
    [SerializeField] Image StopButton;
    public bool Stop = false;
    void Start()
    {
        Shoot.Instance.Power = 0;
        CameraMove.Instance.Speed = 0;
        Background.transform.DOScale(0, 0).SetEase(Ease.OutBack);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameOverClick();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            GameStartClick();
        }
    }
    public void OnButtonClick()
    {
        Shoot.Instance.Power = 0;
        CameraMove.Instance.Speed = 0;
        Background.transform.DOScale(1, 1).SetEase(Ease.OutBack);
        Invoke("TimeStop", 0.8f);
    }
    public void OnExitButtonClick()
    {
        Time.timeScale = 1;
        Invoke("TimeStop", 0.8f);
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
    public void GameStartClick()
    {
        Shoot.Instance.Power = 6;
        CameraMove.Instance.Speed = 2;
        GameStart.transform.DOMove(new Vector3(500, -900, 0), 0.9f).SetEase(Ease.InBack);
        Shop.transform.DOMove(new Vector3(-200, 170, 0), 0.9f).SetEase(Ease.InBack);
        Setting.transform.DOMove(new Vector3(1280, 170, 0), 0.9f).SetEase(Ease.InBack);
        StopButton.transform.DOMove(new Vector3(1000, 1840, 0), 0.9f).SetEase(Ease.InBack);
    }
    public void GameOverClick()
    {
        GameStart.transform.DOMove(new Vector3(540, 170, 0), 0.9f).SetEase(Ease.InBack);
        Shop.transform.DOMove(new Vector3(231, 170, 0), 0.9f).SetEase(Ease.InBack);
        Setting.transform.DOMove(new Vector3(849, 170, 0), 0.9f).SetEase(Ease.InBack);
        StopButton.transform.DOMove(new Vector3(1150, 1840, 0), 0.9f).SetEase(Ease.InBack);
    }
    void TimeStop()
    {
        if (Stop == false)
        {
            Time.timeScale = 0;
            Stop = true;
        }
        else if(Stop == true)
        {
            CameraMove.Instance.Speed = 2;
            Shoot.Instance.Power = 6;
            Stop = false;
        }
    }
}
