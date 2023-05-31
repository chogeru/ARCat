using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCnavMove : MonoBehaviour
{
    [Header("ナビメッシュエージェントとリンク")]
    public NavMeshAgent m_NavMeshAgent;
    [Header("NPCが向かう目標")]
    public Transform m_Target;
 //   [Header("アニメーションリンク")]
  //  public Animator m_Animator;
    [Header("アニメ偏移値")]
    public float m_AnimeSpeed=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //ナビの変数がない場合、自動でリンクする
        if (!m_NavMeshAgent)
            m_NavMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //目標が存在している場合
        if (m_Target)
        {
            if(Vector3.Distance(this.transform.position,m_Target.position)>1.0f)
            {
                //ターゲットまでの距離が一メートル以上
                m_AnimeSpeed += Time.deltaTime;
                if (m_AnimeSpeed > 1.0f) m_AnimeSpeed = 1.0f;
            }
            else
            {
                //一メートル未満
                m_AnimeSpeed -= Time.deltaTime;
                if (m_AnimeSpeed > 0.0f) m_AnimeSpeed = 0.0f;
            }
          //  m_Animator.SetFloat("移動", m_AnimeSpeed);
            //ナビに目標をセットし、常に追いかけさせる
            m_NavMeshAgent.destination = m_Target.position;
        }
    }
}
