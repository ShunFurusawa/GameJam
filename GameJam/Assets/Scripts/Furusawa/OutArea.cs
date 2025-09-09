using System;
using UnityEngine;

namespace Scripts.Furusawa
{
    public class OutArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}