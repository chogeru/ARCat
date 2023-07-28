using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    [SerializeField]
    private int m_Favorability = 0;//�D���x
    [SerializeField]
    private int m_HitPoint;
    [SerializeField]
    private int m_critical;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CatFood"))
        {
            //�X�R�A�����Z����
            ScoreSystem.UpdateScore(m_HitPoint);
            m_Favorability++;
            if (m_Favorability == 5)
            {
                ScoreSystem.UpdateScore(m_critical);
            }
        }
    }
}
