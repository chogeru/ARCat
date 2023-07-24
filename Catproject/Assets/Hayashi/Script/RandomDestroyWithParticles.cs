using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestroyWithParticles : MonoBehaviour
{
    public GameObject particlePrefab; // �p�[�e�B�N���̃v���n�u
    public AudioClip destroySound; // �I�u�W�F�N�g�����ł���ۂ̃T�E���h
    private float minDuration = 30f; // 30���i60�b�j
    private float maxDuration = 60f; // 1���i180�b�j

    private float timeToDestroy;
    private bool isDestroyed;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource�R���|�[�l���g���A�^�b�`����Ă��Ȃ��ꍇ�́A�V���ɒǉ�����
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (destroySound != null)
        {
            audioSource.clip = destroySound;
        }

        // �����_���Ȏ��Ԃ��v�Z���A�I�u�W�F�N�g�����ł�����\�莞����ݒ肷��
        timeToDestroy = Time.time + Random.Range(minDuration, maxDuration);
    }

    private void Update()
    {
        if (!isDestroyed && Time.time >= timeToDestroy)
        {
            // �p�[�e�B�N�����o��
            SpawnParticles();
            // �T�E���h���Đ�����
            if (destroySound != null)
            {
                audioSource.Play();
            }
            // �I�u�W�F�N�g�����ł�����
            Destroy(gameObject);
            isDestroyed = true;
        }
    }

    private void SpawnParticles()
    {
        if (particlePrefab != null)
        {
            // �p�[�e�B�N���̃v���n�u����C���X�^���X�𐶐�
            GameObject particles = Instantiate(particlePrefab, transform.position, Quaternion.identity);

            // �p�[�e�B�N��������������A�p�[�e�B�N����j��
            ParticleSystem ps = particles.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                Destroy(particles, ps.main.duration);
            }
            else
            {
                // ParticleSystem�R���|�[�l���g��������Ȃ������ꍇ�́A�p�[�e�B�N�����Đ����I�������j������
                ParticleSystem.MainModule main = particles.GetComponent<ParticleSystem>().main;
                Destroy(particles, main.duration);
            }
        }
    }
}
