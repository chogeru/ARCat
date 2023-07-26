using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float m_totalTime = 60f; // �J�E���g�_�E���̍��v����
    private float m_currentTime;   // ���݂̎c�莞��
    private Text m_countdownText;  // �e�L�X�g�R���|�[�l���g�ւ̎Q��
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
        if (m_currentTime == 0)//�^�C�}�[��0�ɂȂ�����
        {
            SceneManager.LoadScene(m_sceneName);//���U���g�V�[���Ɉڍs
        }
    }
    private void StartCountdown()
    {
        InvokeRepeating("UpdateCountdown", 1f, 1f); // 1�b���Ƃ�UpdateCountdown���J��Ԃ����s
    }

    private void UpdateCountdown()
    {
        m_currentTime--;
        if (m_currentTime <= 0)
        {
            CancelInvoke("UpdateCountdown"); // �J�E���g�_�E���I�����ɌJ��Ԃ����~
        }
        UpdateCountdownText();
    }

    private void UpdateCountdownText()
    {
        m_countdownText.text = m_currentTime.ToString();
    }
}
