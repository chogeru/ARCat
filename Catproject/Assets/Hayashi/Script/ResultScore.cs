using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultScore : MonoBehaviour
{
    // スコアを表示するテキストオブジェクト
    public Text m_scoreText; 

    private void Start()
    {
        // スコアテキストにゲームシーンから渡されたスコアを表示
        m_scoreText.text = "Score: " + ScoreSystem.m_score.ToString();
    }
}