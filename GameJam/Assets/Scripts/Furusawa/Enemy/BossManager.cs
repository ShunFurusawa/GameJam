using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.Furusawa
{
    public enum BossState
    {
        Patrol,
        Bound,
        Poke
    }
    public class BossManager : MonoBehaviour
    {
        [Header("〇秒後に攻撃切り替え")]
        [SerializeField] private float changeStateTime = 5f;
        [Header("攻撃切り替えのタメ時間")]
        [SerializeField] private float preparationTime = 1f;
        
        [SerializeField] private BossPatrol bossPatrol;
        [SerializeField] private PokeCursor pokeCursor;

        private BossState currentState = BossState.Patrol;
        private float time = 0f;
        private bool isChangingState = false;
        
        private void Start()
        {
            if (bossPatrol == null || pokeCursor == null)
            {
                Debug.LogError("BossPatrol or PokeCursor is not assigned.");
                enabled = false; 
                return;
            }
            StopAllActions();
            OnStateChange();
        }
       
        private void Update()
        {
            if (isChangingState)
                return;
            
            time += Time.deltaTime;
            if (time >= changeStateTime)
            {
                StartCoroutine(RandomChangeState());
                time = 0f; 
            }
        }
        
        private IEnumerator RandomChangeState()
        {
            
            isChangingState = true;
            Debug.Log("全行動停止");
            StopAllActions();
            
            // タメ
            yield return new WaitForSeconds(preparationTime);
            BossState nextState;
            Array values = Enum.GetValues(typeof(BossState));
    
            // ダブったら選びなおす
            do
            {
                int randomIndex = Random.Range(0, values.Length);
                nextState = (BossState)values.GetValue(randomIndex);
            } while (nextState == currentState); 

            currentState = nextState;
            OnStateChange(); // 新しい状態の行動を開始
            Debug.Log("Boss State Changed to: " + currentState);

            isChangingState = false;
        }
        
        private void OnStateChange()
        {
            switch (currentState)
            {
                case BossState.Patrol:
                    bossPatrol.enabled = true;
                    break;
                case BossState.Bound:
                    // Bound攻撃のロジックをここに追加
                    break;
                case BossState.Poke:
                    pokeCursor.enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void StopAllActions()
        {
            bossPatrol.enabled = false;
            pokeCursor.enabled = false;
            // 他の攻撃モードのスクリプトもここで無効化する
        }
        
    }
}