using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject m_objectActive; // �\������I�u�W�F�N�g
    public ParticleSystem m_particleSystem; // �p�[�e�B�N�����Đ�����ParticleSystem�R���|�[�l���g

    private bool isObjectVisible = false;
    private float m_randomTime = 0f;
    private float timer = 0f;
    private float m_minCoolTime = 10;
    private float m_maxCoolTime = 30;
    [SerializeField]
    private float m_falseTime = 3;
    private void Start()
    {
        //�ŏ��ɃI�u�W�F�N�g���\���ɂ���
        m_objectActive.SetActive(false);
        // ����̃����_�����Ԃ�ݒ�
        m_randomTime = GetRandomTime();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isObjectVisible)
        {
            // �I�u�W�F�N�g���\������Ă���ꍇ�A�b�o�߂������\���ɂ���
            if (timer >= m_falseTime)
            {
                HideObject();
            }
        }
        else
        {
            // �I�u�W�F�N�g����\���̏ꍇ�A�����_���Ȏ��Ԍo�߂�����\������
            if (timer >= m_randomTime)
            {
                ShowObject();
            }
        }
    }

    private void ShowObject()
    {
        m_objectActive.SetActive(true); // �I�u�W�F�N�g��\��
        isObjectVisible = true;
        timer = 0f;

        // �p�[�e�B�N�����Đ�
        if (m_particleSystem != null)
        {
            m_particleSystem.Play();
        }

        // �V���������_�����Ԃ�ݒ�
        m_randomTime = GetRandomTime();
    }

    private void HideObject()
    {
        m_objectActive.SetActive(false); // �I�u�W�F�N�g���\��
        isObjectVisible = false;
        timer = 0f;
    }

    private float GetRandomTime()
    {
        return Random.Range(m_minCoolTime, m_maxCoolTime); // �����_���Ȏ��Ԃ�Ԃ�
    }
}