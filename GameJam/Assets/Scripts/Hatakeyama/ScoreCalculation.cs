using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreCalculation : MonoBehaviour
{
    public int Score = 0;
    public Timer timer;
    private int EnemyKillCount = 0;
    private bool BossDefeated = false;
    private int HitCount = 0;


    public void AddEnemyBonus() //敵を倒す度に100点加算
    {
        EnemyKillCount++;

    }
    public void AddBossEnemyBonus() //ボスを倒せたら10000点加算
    {
        BossDefeated = true;
    }
    public void AddHitCount() //球が当たるたびに1点加算
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
            finalScore += Mathf.FloorToInt(timer.RemainTime) * 200;     //残り時間1秒＊200点加算
            ScoreManager.RemainTime = timer.RemainTime;　//残り時間をシーンをまたいで保持
        }
        Score = finalScore;
        
        ScoreManager.FinalScore = Score; // シーンをまたいで保持
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
