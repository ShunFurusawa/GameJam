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
        
        /*private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }*/
    }
}