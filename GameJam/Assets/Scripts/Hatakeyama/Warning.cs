//�x����_�ł����Ȃ���\��������
//1�b��1��_�ŁA3�b�\��
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    [Header("�Ώۂ�UI�摜 (Image)")]
    public Image targetImage;

    [Header("�ݒ�l")]
    public float displayTime = 3f;   // �ŏ��ɕ\�����鎞��
    public float fadeDuration = 1f;  // �����ɂȂ�܂ł̎���
    public float blinkDuration = 1f; // �t�F�[�h�C�� or �t�F�[�h�A�E�g����
    public int blinkCount = 3;       // �J��Ԃ���

    void OnEnable()
    {
        StartCoroutine(ShowAndFade());
    }

    IEnumerator ShowAndFade()
    {
        // �ŏ��͊��S�ɕ\��
        SetAlpha(1f);

        // �w��b���\��
        yield return new WaitForSeconds(displayTime);

        // ���X�ɓ�����
        float elapsed = 0f;         //�o�ߎ��ԋL�^
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            SetAlpha(alpha);
            yield return null;
        }
        SetAlpha(0f);

        // �t�F�[�h�_�ł��w��񐔌J��Ԃ�
        for (int i = 0; i < blinkCount; i++)
        {
            // �t�F�[�h�C��
            elapsed = 0f;
            while (elapsed < blinkDuration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(0f, 1f, elapsed / blinkDuration);
                SetAlpha(alpha);
                yield return null;
            }
            SetAlpha(1f);

            // �t�F�[�h�A�E�g
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
