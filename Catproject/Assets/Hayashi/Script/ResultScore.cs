using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultScore : MonoBehaviour
{
    // �X�R�A��\������e�L�X�g�I�u�W�F�N�g
    public Text m_scoreText; 

    private void Start()
    {
        // �X�R�A�e�L�X�g�ɃQ�[���V�[������n���ꂽ�X�R�A��\��
        m_scoreText.text = "Score: " + ScoreSystem.m_score.ToString();
    }
}