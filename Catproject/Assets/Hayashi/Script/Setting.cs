using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [Header("タイトルCanvas")]
    public GameObject title;
    [Header("音量設定Canvas")]
    public GameObject volume;

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
}
