using UnityEngine;

namespace Scripts.Furusawa
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private float power = 100f;
        [SerializeField] private float shootInterval = 0.5f;
        [SerializeField] GameObject bullet;
        
        private float timer = 0f;

        private void FixedUpdate()
        {
            timer += Time.fixedDeltaTime;

            if (timer >= shootInterval)
            {
                Shoot();
            }
        }
        
        private void Shoot()
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * power);
            timer = 0f;
        }
        
    }
}