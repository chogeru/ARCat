using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cat 
{
    [RequireComponent(typeof(AudioSource))]
    public class CatEffect : MonoBehaviour
    {
        [Header("�e�������������̃p�[�e�B�N��")]
        [SerializeField] ParticleSystem hitParticlePrefub; // ���e�����o�v���n�u 
        [Header("�L�̐�")]
        public AudioSource catVoice;
        public AudioClip[] catSounds; // 4��ނ̔L�̐��̃I�[�f�B�I�N���b�v

        private void OnCollisionEnter(Collision collision)
        {
            // ���e���ɉ��o�����Đ��̃Q�[���I�u�W�F�N�g�𐶐�
            Instantiate(hitParticlePrefub, transform.position, transform.rotation);
            // �p�[�e�B�N���̍Đ�
            hitParticlePrefub.Play();

            // �����_���ɔL�̐����Đ�
            int randomSoundIndex = Random.Range(0, catSounds.Length);
            catVoice.clip = catSounds[randomSoundIndex];
            catVoice.Play();
        }
    }
}
