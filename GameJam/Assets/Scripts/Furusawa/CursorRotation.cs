using UnityEngine;

namespace Scripts.Furusawa
{
    public class CursorRotation : MonoBehaviour
    {
        [Header("回転量")]
        [SerializeField] private float rotationAmount = 1.0f;
        [Header("ホイールで回転させるか")]
        [SerializeField] private bool isWheelRotate = true;
        private void Update()
        {
            if (isWheelRotate)
            {
                WheelRotate();
            }
            else
            {
                ClickRotate();
            }
        }

        private void WheelRotate()
        {
            float rotation = Input.GetAxis("Mouse ScrollWheel") * rotationAmount;
            
            transform.Rotate(0, 0, rotation);
        }

        private void ClickRotate()
        {
            float rotation;
            if (Input.GetMouseButton(0))
            {
                rotation =  rotationAmount;
            }
            else if (Input.GetMouseButton(1))
            {
                rotation = -rotationAmount;
            }
            else
            {
                rotation = 0;
            }
            
            transform.Rotate(0, 0, rotation);
          
        }
    }
}