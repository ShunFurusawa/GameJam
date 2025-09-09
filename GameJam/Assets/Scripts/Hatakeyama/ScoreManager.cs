using UnityEngine;
using TMPro;
public static class ScoreManager
{
    public static int FinalScore = 0;           //�ŏI�X�R�A
    public static float RemainTime = 0; // �c�莞�Ԃ�ێ�


    public static void SaveScore(int score)     //�X�R�A�ۑ�
    {
        FinalScore = score;
        Debug.Log("Score Saved: " + FinalScore);
    }

    
    public static int GetScore()                //�X�R�A�K��
    {
        return FinalScore;
    }
    public static void ShowScore(TextMeshProUGUI scoreText)     //�X�R�A�\��
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
