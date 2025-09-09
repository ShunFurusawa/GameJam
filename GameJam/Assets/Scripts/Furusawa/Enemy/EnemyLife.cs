using UnityEngine;
using System.Collections; // コルーチンを使用するために必要

namespace Scripts.Furusawa
{
    public class EnemyLife : MonoBehaviour
    {
        [Tooltip("ライフが0になったらオブジェクトを破壊するかどうか")]
        [SerializeField] private bool isDestroyedOnZeroLife = true; // ライフが0になったらオブジェクトを破壊するかどうか
        [SerializeField] private int life = 3;

        [Header("被ダメ画像表示時間")]
        [SerializeField] private float flashDuration = 0.1f; // スプライトを切り替えている時間
        [Header("被ダメ画像")]
        [SerializeField] private Sprite damageSprite;
        [Header("やられ画像")]
        [SerializeField] private Sprite deadSprite; 
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private Sprite originalSprite; // 元のスプライトを保存するための変数

        private void Awake()
        {
            // このオブジェクトのSpriteRendererコンポーネントを取得
            spriteRenderer = GetComponent<SpriteRenderer>();
            // 開始時の通常スプライトを保存しておく
            originalSprite = spriteRenderer.sprite;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                life--;
                Destroy(other.gameObject);

                // ライフが0より大きい場合（まだ生きている場合）のみ、ヒット表現を行う
                if (life > 0)
                {
                    StartCoroutine(HitFlashCoroutine());
                }
                else
                {
                    // ライフが0になったらオブジェクトを破壊
                    if (isDestroyedOnZeroLife)
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        spriteRenderer.sprite = deadSprite;
                    }
                }
            }
        }

        /// <summary>
        /// 被ダメージ時のスプライト切り替えを行うコルーチン
        /// </summary>
        private IEnumerator HitFlashCoroutine()
        {
            // スプライトを被ダメージ用の画像に切り替え
            spriteRenderer.sprite = damageSprite;

            // 指定された秒数だけ待機
            yield return new WaitForSeconds(flashDuration);

            // スプライトを元の通常画像に戻す
            spriteRenderer.sprite = originalSprite;
        }
    }
}