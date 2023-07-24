using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cat;
namespace UI
{
    public class Zukan : MonoBehaviour
    {
        //�}�ӂ�UI
        [Header("�}�ӂ�UI")]
        public GameObject m_Zukan;
        //�}�ӂ�\������{�^��
        [Header("�}�ӂ�\������{�^��")]
        public GameObject m_ZukanGoButtan;
        //�T�E���h�������
        [Header("���ʒ������")]
        public GameObject m_SoundCanvas;
        //�e
        [Header("�a���ˋ@")]
        public GameObject m_Shooter;
        //�ݒ�p��UI
        [Header("�ݒ�p��Canvas")]
        public GameObject m_SettingCanvas;
        public GameObject m_SettingUI;
        //�}�ӂ�UI

        public GameObject m_ZukanUI;
        //�Q�[����ʗpUI
        public GameObject m_GameUI;
        //�ӏ܃��[�h
        public GameObject m_ViewingMode;
        //�ݒ�pCanvas�w�i
        public GameObject m_BuckGround;
        public void Start()
        {
            //�}�ӕ\���p�{�^����\��
            m_GameUI.SetActive(true);
            //�e���A�N�e�B�u��
            m_Shooter.SetActive(true);
        }
        public void GoZukan()
        {
            //�}��UI��\��
            m_ZukanUI.SetActive(true);
            //�Q-����ʂ�UI
            m_GameUI.SetActive(false);
            //�ݒ��ʂ�Canvas���\����
            m_SettingCanvas.SetActive(false);
            //�e���g���Ȃ��悤��
            m_Shooter.SetActive(false);
            //�ݒ�p��UI���\��
            m_SettingCanvas.SetActive(false);
        }

        public void GoSetting()
        {
            //�Q�[����ʂ�UI��\��
            m_SettingCanvas.SetActive(true);
            //�}�ӂ�UI
            m_ZukanUI.SetActive(false);
            //�e���A�N�e�B�u
            m_Shooter.SetActive(true);
        }
        public void CloseSettingCanvas()
        {
            m_SettingCanvas.SetActive(true);
            m_GameUI.SetActive(true);
            m_BuckGround.SetActive(false);
        }
        public void  OpenSoundCanvas()
        {
            m_SoundCanvas.SetActive(true);
            m_SettingUI.SetActive(false);
        }
        public void CloseSoundCanvas()
        {
            m_SettingUI.SetActive(true);
            m_SoundCanvas.SetActive(false);
        }
        public void OpenViewingMode()
        {
            m_ViewingMode.SetActive(true);
            m_SettingUI.SetActive(false);
            m_BuckGround.SetActive(false);
        }
        public void CloseViewingMode()
        {
            m_ViewingMode.SetActive(false);
            m_SettingUI.SetActive(true);
            m_BuckGround.SetActive(true);
        }
    }
}