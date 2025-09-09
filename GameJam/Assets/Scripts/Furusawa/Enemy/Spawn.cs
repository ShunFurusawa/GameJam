using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Furusawa
{
    public class Spawn : MonoBehaviour
    {
        [FormerlySerializedAs("bossPrefab")] [SerializeField] private GameObject bossGameObject; // 出現させる敵のプレハブ
        [SerializeField] private Transform enemiesParent; // 敵をまとめている親オブジェクトのTransform
        
        private bool hasBossSpawned = false; // ボスが既に出現したかどうかのフラグ

        private void Start()
        {
            // ゲーム開始時にボスを非表示にしておく
            if (bossGameObject != null)
            {
                bossGameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("Boss GameObjectがインスペクターで設定されていません！");
            }
        }

        private void Update()
        {
            // まだボスが出現しておらず、enemiesParentの子オブジェクト（敵）が0体になったら
            if (!hasBossSpawned && enemiesParent.childCount == 0)
            {
                SpawnBoss();
            }
        }

        /// <summary>
        /// ボスを生成する
        /// </summary>
        private void SpawnBoss()
        {
            // ボスをこのオブジェクトの位置に出現させる
            
            bossGameObject.SetActive(true);
            
            // ボスが出現したことをフラグで記録
            hasBossSpawned = true;
            
            Debug.Log("全ての敵を倒したため、ボスが出現しました！");

            // このスクリプトの役目は終わったので、無効化して負荷を減らす
            this.enabled = false;
        }
    }
}