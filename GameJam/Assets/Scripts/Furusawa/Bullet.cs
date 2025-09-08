using System;
using UnityEngine;

namespace Scripts.Furusawa
{
    public class Bullet : MonoBehaviour
    {
   

        // 画面外に出たら消す
        public void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}