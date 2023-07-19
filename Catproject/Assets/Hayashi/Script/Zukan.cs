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
        //銃
        [Header("餌発射機")]
        public GameObject m_Shooter;
        //設定用のUI
        [Header("設定用のCanvas")]
        public GameObject m_SettingCanvas;
        //図鑑のUI

        public GameObject m_ZukanUI;
        //ゲーム画面用UI
        public GameObject m_GameUI;
     
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
            //銃を使えないように
            m_Shooter.SetActive(false);
            //設定用のUIを非表示
            m_SettingCanvas.SetActive(false);
        }

        public void GoGame()
        {
            //ゲーム画面のUIを表示
            m_GameUI.SetActive(true);
            //図鑑のUI
            m_ZukanUI.SetActive(false);
            //銃をアクティブ
            m_Shooter.SetActive(true);
        }
    }
}