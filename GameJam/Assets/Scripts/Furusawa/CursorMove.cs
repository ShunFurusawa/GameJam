using System;
using UnityEngine;

namespace Scripts.Furusawa
{
    public class CursorMove : MonoBehaviour
    {
        [Header("カーソルを表示するか")]
        [SerializeField] private bool isDebug;
        
        /*[Header("表示する偽カーソルのオブジェクト(画像？)")]
        [SerializeField] private GameObject cursor;*/

        private Vector2 mouse;
        private Vector2 target;

        private void Start()
        {
            Cursor.visible = isDebug;
        }

        private void Update()
        {
            mouse = Input.mousePosition;
            target = Camera.main.ScreenToWorldPoint(mouse);
            
            transform.position = target;
        }
    }
}

