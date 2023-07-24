using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cat;
namespace UI
{
    public class Zukan : MonoBehaviour
    {
        //図鑑のUI
        [Header("図鑑のUI")]
        public GameObject m_Zukan;
        //図鑑を表示するボタン
        [Header("図鑑を表示するボタン")]
        public GameObject m_ZukanGoButtan;
        //サウンド調整画面
        [Header("音量調整画面")]
        public GameObject m_SoundCanvas;
        //銃
        [Header("餌発射機")]
        public GameObject m_Shooter;
        //設定用のUI
        [Header("設定用のCanvas")]
        public GameObject m_SettingCanvas;
        public GameObject m_SettingUI;
        //図鑑のUI

        public GameObject m_ZukanUI;
        //ゲーム画面用UI
        public GameObject m_GameUI;
        //鑑賞モード
        public GameObject m_ViewingMode;
        //設定用Canvas背景
        public GameObject m_BuckGround;
        public void Start()
        {
            //図鑑表示用ボタンを表示
            m_GameUI.SetActive(true);
            //銃をアクティブに
            m_Shooter.SetActive(true);
        }
        public void GoZukan()
        {
            //図鑑UIを表示
            m_ZukanUI.SetActive(true);
            //ゲ-ム画面のUI
            m_GameUI.SetActive(false);
            //設定画面のCanvasを非表示に
            m_SettingCanvas.SetActive(false);
            //銃を使えないように
            m_Shooter.SetActive(false);
            //設定用のUIを非表示
            m_SettingCanvas.SetActive(false);
        }

        public void GoSetting()
        {
            //ゲーム画面のUIを表示
            m_SettingCanvas.SetActive(true);
            //図鑑のUI
            m_ZukanUI.SetActive(false);
            //銃をアクティブ
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