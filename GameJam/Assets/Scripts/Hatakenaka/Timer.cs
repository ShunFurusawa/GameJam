using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public float Starttime = 120f;
    private float RemainTime = 0f;
    private bool isRunning = true; 
     void Start()
    {
        RemainTime = Starttime;
        timerText.gameObject.SetActive(true);
    }
    void Update()
    {
        if (isRunning)
        {
            RemainTime-= Time.deltaTime;
            if (RemainTime <= 0f) 
            {
                RemainTime = 0f;
                isRunning = false;
                timerText.text = "00:00:00";
                StartCoroutine(HideAfterDelay(2f));
                
                Debug.Log("Time Up");
                return;
            }
            int minutes = Mathf.FloorToInt(RemainTime/60f);
            int seconds = Mathf.FloorToInt(RemainTime%60f);
            int miniseconds = Mathf.FloorToInt((RemainTime*100f)%100);
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, miniseconds);
        }
    }
    IEnumerator HideAfterDelay(float delay)     //1秒遅らせてからタイマー非表示
    {
        yield return new WaitForSeconds(delay);
        timerText.gameObject.SetActive(false);
    }
    // タイマーを止める処理
    public void StopTimer()
    {
        isRunning = false;

    }

    // タイマーをリセットする処理
    public void ResetTimer()
    {
        RemainTime = Starttime;
        isRunning = true;
        timerText.gameObject.SetActive(true);
    }

}
