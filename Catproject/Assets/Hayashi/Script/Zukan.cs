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
        public GameObject zukan;
        //�}�ӂ�\������{�^��
        [Header("�}�ӂ�\������{�^��")]
        public GameObject zukanGoButtan;
        //�e
        [Header("�a���ˋ@")]
        public GameObject shooter;
        //�ݒ�p��UI
        [Header("�ݒ�p��Canvas")]
        public GameObject settingCanvas;
        //�}�ӂ�UI

        public GameObject zukanUI;
        //�Q�[����ʗpUI
        public GameObject gameUI;
     
        public void Start()
        {
            //�}�ӕ\���p�{�^����\��
            gameUI.SetActive(true);
            //�e���A�N�e�B�u��
            shooter.SetActive(true);
        }
        public void GoZukan()
        {
            //�}��UI��\��
            zukanUI.SetActive(true);
            //�Q-����ʂ�UI
            gameUI.SetActive(false);
            //�e���g���Ȃ��悤��
            shooter.SetActive(false);
            //�ݒ�p��UI���\��
            settingCanvas.SetActive(false);
        }

        public void GoGame()
        {
            //�Q�[����ʂ�UI��\��
            gameUI.SetActive(true);
            //�}�ӂ�UI
            zukanUI.SetActive(false);
            //�e���A�N�e�B�u
            shooter.SetActive(true);
        }
    }
}