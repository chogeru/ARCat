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
        //�e
        [Header("�a���ˋ@")]
        public GameObject m_Shooter;
        //�ݒ�p��UI
        [Header("�ݒ�p��Canvas")]
        public GameObject m_SettingCanvas;
        //�}�ӂ�UI

        public GameObject m_ZukanUI;
        //�Q�[����ʗpUI
        public GameObject m_GameUI;
     
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
            //�e���g���Ȃ��悤��
            m_Shooter.SetActive(false);
            //�ݒ�p��UI���\��
            m_SettingCanvas.SetActive(false);
        }

        public void GoGame()
        {
            //�Q�[����ʂ�UI��\��
            m_GameUI.SetActive(true);
            //�}�ӂ�UI
            m_ZukanUI.SetActive(false);
            //�e���A�N�e�B�u
            m_Shooter.SetActive(true);
        }
    }
}