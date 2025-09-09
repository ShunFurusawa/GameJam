using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreCalculation : MonoBehaviour
{
    public int Score = 0;
    public Timer timer;
    private int EnemyKillCount = 0;
    private bool BossDefeated = false;
    private int HitCount = 0;


    public void AddEnemyBonus() //�G��|���x��100�_���Z
    {
        EnemyKillCount++;

    }
    public void AddBossEnemyBonus() //�{�X��|������10000�_���Z
    {
        BossDefeated = true;
    }
    public void AddHitCount() //���������邽�т�1�_���Z
    {
        HitCount++;
    }
    public int ScoreCalculate()
    {
        int finalScore = 0;
        finalScore += EnemyKillCount * 100;
        finalScore += HitCount ;
        if (BossDefeated)
        {
            finalScore += 10000;
        }
        if (timer != null)
        {
            finalScore += Mathf.FloorToInt(timer.RemainTime) * 200;     //�c�莞��1�b��200�_���Z
            ScoreManager.RemainTime = timer.RemainTime;�@//�c�莞�Ԃ��V�[�����܂����ŕێ�
        }
        Score = finalScore;
        
        ScoreManager.FinalScore = Score; // �V�[�����܂����ŕێ�
        Debug.Log("Final Score: " + Score);

        return Score;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
