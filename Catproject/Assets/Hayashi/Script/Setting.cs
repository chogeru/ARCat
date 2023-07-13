using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI
{
    public class Setting : MonoBehaviour
    {
        [Header("タイトルCanvas")]
        [Space(10)]
        public GameObject title;
        [Header("音量設定Canvas")]
        [Space(10)]
        public GameObject volume;
        [Header("餌発射機")]
        [Space(10)]
        public GameObject shooter;
        [Header("設定用Canvas")]
        [Space(10)]
        public GameObject settingButton;
        [Header("ゲーム画面Canvas")]
        [Space(10)]
        public GameObject gamescreen;

        public void VolumeSetting()
        {
            //タイトルを非表示
            title.SetActive(false);
            //音量設定画面を表示
            volume.SetActive(true);

        }
        public void GoTitle()
        {
            //タイトルを表示
            title.SetActive(true);
            //音量設定画面を非表示
            volume.SetActive(false);

        }
        public void GameSetting()
        {
            shooter.SetActive(false);
            settingButton.SetActive(true);
            gamescreen.SetActive(false);
        }
        public void CloseSetting()
        {
            settingButton.SetActive(false);
            gamescreen.SetActive(true);
            shooter.SetActive(true);
        }
    }
}