using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class Bgm : MonoBehaviour
    {
        [SerializeField]
        SoundManager soundManager;
        [SerializeField]
        AudioClip clip;
        public Slider slider;
        AudioSource audioSource;
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            soundManager.PlayBgm(clip);
            slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
        }
    }

