using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace Scripts.Furusawa
{
    public class PokeCursor : MonoBehaviour
    {
        [SerializeField] private float speed = 5f; // 追従速度
        
        [FormerlySerializedAs("pokeInterval")]
        [FormerlySerializedAs("chaseInterval")]
        [Header("〇秒に一回突っ込む")]
        [SerializeField] private float pokeDuration = 3f;
        [Header("待機と回転の設定")]
        [SerializeField] private float waitTime = 1f; 
        [SerializeField] private float rotationSpeed = 5f; 
        
        [Header("突っ込むオブジェクト")]
        [SerializeField] private Transform targetObject;
        
        private bool isPoking = false;
        private float pokeTimer = 0f;
        private Vector2 directionToTarget;

        private void OnEnable()
        {
            if (targetObject == null)
            {
                Debug.LogError("Target Object is not assigned.");
                enabled = false; 
                return;
            }
            
            // 最初の行動を開始
            StartCoroutine(WaitAndRotate());
        }
        
        private void Update()
        {
            if (isPoking)
            {
                pokeTimer += Time.deltaTime;
                Poke();
                
                // 突進時間が上限に達したら、次の準備へ
                if (pokeTimer >= pokeDuration)
                {
                    ResetStateAndPrepareNextPoke();
                }
            }
        }

        private void Poke()
        {
            transform.position += (Vector3)directionToTarget * speed * Time.deltaTime;
        }
        
        private IEnumerator WaitAndRotate()
        {
            // 突進が始まる前に方向を一度だけ計算
            directionToTarget = (targetObject.position - transform.position).normalized;
            
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f)); 
            
            float elapsedTime = 0f;
            while (elapsedTime < waitTime)
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
                elapsedTime += Time.deltaTime;
                yield return null; 
            }
            
            transform.rotation = targetRotation;
            
            // Pokeの開始
            isPoking = true;
            pokeTimer = 0f;
        }
        
        /// <summary>
        /// 2Dの衝突が発生したときに呼ばれるUnityのイベント関数
        /// </summary>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 突進中、かつ衝突した相手のタグが"Wall"の場合のみ処理
            if (isPoking && collision.gameObject.CompareTag("Wall"))
            {
                Debug.Log("壁に衝突！次の攻撃準備に入ります。");
                ResetStateAndPrepareNextPoke();
            }
        }

        /// <summary>
        /// 突進状態をリセットし、次の準備コルーチンを開始する
        /// </summary>
        private void ResetStateAndPrepareNextPoke()
        {
            isPoking = false;
            pokeTimer = 0f;
            
            // 実行中のコルーチンを念のため全て停止
            StopAllCoroutines();
            StartCoroutine(WaitAndRotate());
        }
    }
}