using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Furusawa
{
    public class BossPatrol : MonoBehaviour
    {
        [SerializeField] private Transform waypointParent;
        [SerializeField] private float moveSpeed = 3f;
        
        [Header("待機と回転の設定")]
        [SerializeField] private float waitTime = 2f; // ポイントでの待機時間（秒）
        [SerializeField] private float rotationSpeed = 5f; // 回転の速さ
        
        private Transform[] waypoints;
        private int currentWaypointIndex = 0;
        private bool isWaiting = false; 

        private void Awake()
        {
            // 全部の巡回地点取得
            waypoints = new Transform[waypointParent.childCount];
            for (int i = 0; i < waypointParent.childCount; i++)
            {
                waypoints[i] = waypointParent.GetChild(i);
            }

            if (waypoints.Length == 0)
            {
                Debug.LogError("No waypoints found");
            }
        
        }

        private void OnEnable()
        {
            isWaiting = true; 
            StartCoroutine(WaitAndRotate());
        }

        private void Update()
        {
            MoveToNextWaypoint();
        }

    
        private void MoveToNextWaypoint()
        {
            if (waypoints.Length == 0 || isWaiting)
                return;
            
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            
            // 移動 position直接変える方がいいらしい
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetWaypoint.position,
                moveSpeed * Time.deltaTime
            );
            
            // 目標地点に十分に近づいたら、次の目標地点へ
            if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                isWaiting = true; 
                StartCoroutine(WaitAndRotate());
            }
        }

        private IEnumerator WaitAndRotate()
        {
            // 次の目標地点を計算
            int nextWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            Transform nextTarget = waypoints[nextWaypointIndex];
            
            Vector2 directionToTarget = (nextTarget.position - transform.position).normalized;
            // Atan2で角度を計算し、Quaternionに変換 
            // Atan2はラジアンを返すから度数法に変換 (Rad2Deg)
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f)); // スプライトの向きに合わせて90度補正
            
            float elapsedTime = 0f;
            while (elapsedTime < waitTime)
            {
                // Slerpで少しずつ回転
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
                elapsedTime += Time.deltaTime;
                yield return null; // 1フレーム待つ
            }
            
            // 回転のズレをなくすため、最後に目標角度を設定
            transform.rotation = targetRotation;
            
            // 次の目標地点に更新
            currentWaypointIndex = nextWaypointIndex;
            
            isWaiting = false;
        }
    }
}
