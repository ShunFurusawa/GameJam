using UnityEngine;
using TMPro;
public class ShowResult : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreManager.ShowScore(scoreText);      //スコア表示
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
