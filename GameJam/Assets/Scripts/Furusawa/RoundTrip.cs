using UnityEngine;

namespace Scripts.Furusawa
{
    public class RoundTrip : MonoBehaviour
    {
        /// <summary>
        /// 移動を開始する方向を定義
        /// </summary>
        public enum StartingDirection
        {
            Left,
            Right
        }

        [Header("移動設定")]
        [SerializeField]
        [Tooltip("往復運動の速さ")]
        private float speed = 1f;

        [SerializeField]
        [Tooltip("初期位置から左右それぞれに移動する距離")]
        private float distance = 3f;

        [SerializeField]
        [Tooltip("最初に移動を開始する方向")]
        private StartingDirection startDirection = StartingDirection.Right;

        private Vector3 startPosition;
        private float directionMultiplier = 1f;

        private void Start()
        {
            // 実行時の初期位置を記憶
            startPosition = transform.position;

            // 左開始の場合は波形を反転させる
            if (startDirection == StartingDirection.Left)
            {
                directionMultiplier = -1f;
            }
        }

        private void Update()
        {
            // Sin波の計算。Time.time * speed で速さを調整し、distanceで振れ幅を調整
            float oscillation = Mathf.Sin(Time.time * speed) * distance * directionMultiplier;
        
            // 初期位置に計算結果を加算して、新しいX座標を求める
            float newX = startPosition.x + oscillation;
        
            // 座標を更新
            transform.position = new Vector3(newX, startPosition.y, startPosition.z);
        }
    }
}