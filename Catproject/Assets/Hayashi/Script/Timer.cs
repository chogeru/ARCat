using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float m_totalTime = 60f; // カウントダウンの合計時間
    private float m_currentTime;   // 現在の残り時間
    private Text m_countdownText;  // テキストコンポーネントへの参照
    [SerializeField]
    private string m_sceneName = "";

    private void Start()
    {
        m_countdownText = GetComponent<Text>();
        m_currentTime = m_totalTime;
        UpdateCountdownText();
        StartCountdown();
    }
    private void Update()
    {
        if (m_currentTime == 0)//タイマーが0になったら
        {
            SceneManager.LoadScene(m_sceneName);//リザルトシーンに移行
        }
    }
    private void StartCountdown()
    {
        InvokeRepeating("UpdateCountdown", 1f, 1f); // 1秒ごとにUpdateCountdownを繰り返し実行
    }

    private void UpdateCountdown()
    {
        m_currentTime--;
        if (m_currentTime <= 0)
        {
            CancelInvoke("UpdateCountdown"); // カウントダウン終了時に繰り返しを停止
        }
        UpdateCountdownText();
    }

    private void UpdateCountdownText()
    {
        m_countdownText.text = m_currentTime.ToString();
    }
}
