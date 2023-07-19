using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cat 
{
    [RequireComponent(typeof(AudioSource))]
    public class CatEffect : MonoBehaviour
    {
        [Header("弾があたった時のパーティクル")]
        [SerializeField] ParticleSystem hitParticlePrefub; // 着弾時演出プレハブ 
        [Header("猫の声")]
        public AudioSource catVoice;
        public AudioClip[] catSounds; // 4種類の猫の声のオーディオクリップ

        private void OnCollisionEnter(Collision collision)
        {
            // 着弾時に演出自動再生のゲームオブジェクトを生成
            Instantiate(hitParticlePrefub, transform.position, transform.rotation);
            // パーティクルの再生
            hitParticlePrefub.Play();

            // ランダムに猫の声を再生
            int randomSoundIndex = Random.Range(0, catSounds.Length);
            catVoice.clip = catSounds[randomSoundIndex];
            catVoice.Play();
        }
    }
}
