//警告を点滅させながら表示させる
//1秒に1回点滅、3秒表示
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    [Header("対象のUI画像 (Image)")]
    public Image targetImage;

    [Header("設定値")]
    public float displayTime = 3f;   // 最初に表示する時間
    public float fadeDuration = 1f;  // 透明になるまでの時間
    public float blinkDuration = 1f; // フェードイン or フェードアウト時間
    public int blinkCount = 3;       // 繰り返し回数

    void OnEnable()
    {
        StartCoroutine(ShowAndFade());
    }

    IEnumerator ShowAndFade()
    {
        // 最初は完全に表示
        SetAlpha(1f);

        // 指定秒数表示
        yield return new WaitForSeconds(displayTime);

        // 徐々に透明に
        float elapsed = 0f;         //経過時間記録
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0f);

        // フェード点滅を指定回数繰り返す
        for (int i = 0; i < blinkCount; i++)
        {
            // フェードイン
            elapsed = 0f;
            while (elapsed < blinkDuration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(0f, 1f, elapsed / blinkDuration);
                SetAlpha(alpha);
                yield return null;
            }
            SetAlpha(1f);

            // フェードアウト
            elapsed = 0f;
            while (elapsed < blinkDuration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsed / blinkDuration);
                SetAlpha(alpha);
                yield return null;
            }
            SetAlpha(0f);
        }

    
        SetAlpha(0f);
    }

    void SetAlpha(float alpha)
    {
        if (targetImage != null)
        {
            Color c = targetImage.color;
            c.a = alpha;
            targetImage.color = c;
        }
    }
}
