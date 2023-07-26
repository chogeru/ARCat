using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    public GameObject[] m_Cats; // 6�C�̔L���i�[����z��
    private int m_currentIndex = 0; // ���ݕ\������Ă���L�����N�^�[�̃C���f�b�N�X

    private void Start()
    {
        // �ŏ��̔L�̂ݕ\������
        ShowCat(m_currentIndex);
    }

    public void SwitchCat(bool isRight)
    {
        // ���E�̃{�^���ɂ���ĔL��؂�ւ���
        if (isRight)
        {
            // �E�{�^�����������ꍇ�A���̔L��
            m_currentIndex = (m_currentIndex + 1) % m_Cats.Length;
        }
        else
        {
            // ���{�^�����������ꍇ�A�O�̔L��
            m_currentIndex = (m_currentIndex - 1 + m_Cats.Length) % m_Cats.Length; 
        }

        // ���ݕ\������Ă���L���\���ɂ���
        HideAllCat();
        // �V�����L��\������
        ShowCat(m_currentIndex);
    }

    private void HideAllCat()
    {
        // �S�Ă̔L���\���ɂ���
        foreach (GameObject character in m_Cats)
        {
            character.SetActive(false);
        }
    }

    private void ShowCat(int index)
    {
        // �w�肳�ꂽ�C���f�b�N�X�̔L��\������
        m_Cats[index].SetActive(true);
    }
}
