using UnityEngine;
using TMPro;
public static class ScoreManager
{
    public static int FinalScore = 0;           //最終スコア
    public static float RemainTime = 0; // 残り時間を保持


    public static void SaveScore(int score)     //スコア保存
    {
        FinalScore = score;
        Debug.Log("Score Saved: " + FinalScore);
    }

    
    public static int GetScore()                //スコア習得
    {
        return FinalScore;
    }
    public static void ShowScore(TextMeshProUGUI scoreText)     //スコア表示
    {
        if (scoreText != null)
        {
            scoreText.text = "" + FinalScore;
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned");
        }
    }
}
