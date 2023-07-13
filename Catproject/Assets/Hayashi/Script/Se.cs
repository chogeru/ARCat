using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Sound
{
    public class Se : MonoBehaviour
    {
        [SerializeField]
        SoundManager soundManager;
        [SerializeField]
        AudioClip clip;
        public Slider slider;
        AudioSource audioSource;
        public void PlaySE()
        {
            audioSource = GetComponent<AudioSource>();
            soundManager.PlaySe(clip);
            slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
        }
    }
}


