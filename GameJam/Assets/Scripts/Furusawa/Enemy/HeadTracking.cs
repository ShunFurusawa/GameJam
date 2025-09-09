using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Furusawa
{
    public class HeadTracking : MonoBehaviour
    {
        [SerializeField] private Transform head; 
        [SerializeField] private List<Transform> bodyParts; 

        [Header("パーツ間の距離")]
        [SerializeField] private float bodyDistance = 0.8f;
        [Header("胴体の追従の滑らかさ")]
        [SerializeField] private float bodySmoothSpeed = 10f; 

        private void Update()
        {
            MoveBody();
        }
        
        private void MoveBody()
        {
            if (bodyParts.Count == 0) return;

            // 最初の胴体は、頭を追いかける ---
            Follow(bodyParts[0], head, bodySmoothSpeed);

            // 2番目以降の胴体は、一つ前を追いかける
            for (int i = 1; i < bodyParts.Count; i++)
            {
                Follow(bodyParts[i], bodyParts[i - 1], bodySmoothSpeed);
            }
        }
        
        // targetToFollowを追いかけるfollowerの動きを処理する関数
        private void Follow(Transform follower, Transform targetToFollow, float speed)
        {
            // ターゲットとの距離がbodyDistanceより離れていたら近づく
            float currentDistance = Vector2.Distance(follower.position, targetToFollow.position);
            if (currentDistance > bodyDistance)
            {
                // ターゲットの少し後ろの位置を目標地点に
                Vector3 targetPosition = targetToFollow.position - (targetToFollow.position - follower.position).normalized * bodyDistance;

                // Lerpを使って滑らかに移動させる
                follower.position = Vector3.Lerp(follower.position, targetPosition, Time.deltaTime * speed);
            }
        
            // 常にターゲットの方向を向く（滑らかに回転）
            Vector2 direction = targetToFollow.position - follower.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90f); // -90fはスプライトの向きに合わせる調整値
            follower.rotation = Quaternion.Slerp(follower.rotation, targetRotation, Time.deltaTime * speed);
        }
    }
}