using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    private Text m_scoretext;
    public static int m_score=0;
    // Start is called before the first frame update
    void Start()
    {
        m_scoretext = GetComponent<Text>();
        m_scoretext.text = "Score:0";
    }

    // Update is called once per frame
    void Update()
    {
        m_scoretext.text = m_score.ToString();
    }
    public static void UpdateScore(int pointsToAdd)
    {
        m_score += pointsToAdd;
    }
}
