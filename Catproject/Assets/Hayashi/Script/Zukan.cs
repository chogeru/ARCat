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
        public GameObject zukan;
        //図鑑を表示するボタン
        [Header("図鑑を表示するボタン")]
        public GameObject zukanGoButtan;
        //銃
        [Header("餌発射機")]
        public GameObject shooter;
        //設定用のUI
        [Header("設定用のCanvas")]
        public GameObject settingCanvas;
        //図鑑のUI

        public GameObject zukanUI;
        //ゲーム画面用UI
        public GameObject gameUI;
     
        public void Start()
        {
            //図鑑表示用ボタンを表示
            gameUI.SetActive(true);
            //銃をアクティブに
            shooter.SetActive(true);
        }
        public void GoZukan()
        {
            //図鑑UIを表示
            zukanUI.SetActive(true);
            //ゲ-ム画面のUI
            gameUI.SetActive(false);
            //銃を使えないように
            shooter.SetActive(false);
            //設定用のUIを非表示
            settingCanvas.SetActive(false);
        }

        public void GoGame()
        {
            //ゲーム画面のUIを表示
            gameUI.SetActive(true);
            //図鑑のUI
            zukanUI.SetActive(false);
            //銃をアクティブ
            shooter.SetActive(true);
        }
    }
}