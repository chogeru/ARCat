using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject m_objectActive; // 表示するオブジェクト
    public ParticleSystem m_particleSystem; // パーティクルを再生するParticleSystemコンポーネント

    private bool isObjectVisible = false;
    private float m_randomTime = 0f;
    private float timer = 0f;
    private float m_minCoolTime = 10;
    private float m_maxCoolTime = 30;
    [SerializeField]
    private float m_falseTime = 3;
    private void Start()
    {
        //最初にオブジェクトを非表示にする
        m_objectActive.SetActive(false);
        // 初回のランダム時間を設定
        m_randomTime = GetRandomTime();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isObjectVisible)
        {
            // オブジェクトが表示されている場合、秒経過したら非表示にする
            if (timer >= m_falseTime)
            {
                HideObject();
            }
        }
        else
        {
            // オブジェクトが非表示の場合、ランダムな時間経過したら表示する
            if (timer >= m_randomTime)
            {
                ShowObject();
            }
        }
    }

    private void ShowObject()
    {
        m_objectActive.SetActive(true); // オブジェクトを表示
        isObjectVisible = true;
        timer = 0f;

        // パーティクルを再生
        if (m_particleSystem != null)
        {
            m_particleSystem.Play();
        }

        // 新しいランダム時間を設定
        m_randomTime = GetRandomTime();
    }

    private void HideObject()
    {
        m_objectActive.SetActive(false); // オブジェクトを非表示
        isObjectVisible = false;
        timer = 0f;
    }

    private float GetRandomTime()
    {
        return Random.Range(m_minCoolTime, m_maxCoolTime); // ランダムな時間を返す
    }
}