﻿using System;
using UnityEngine;

namespace Scripts.Furusawa
{
    public class PlayBGM : MonoBehaviour
    {
        [Header("再生するBGM")]
        [SerializeField] private string BGM_name;

        private void Start()
        {
            if (!string.IsNullOrEmpty(BGM_name))
            {
                SoundManager.instance.Play(BGM_name);
            }
        }
    }
}