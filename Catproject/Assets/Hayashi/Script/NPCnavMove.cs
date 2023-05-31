using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCnavMove : MonoBehaviour
{
    [Header("�i�r���b�V���G�[�W�F���g�ƃ����N")]
    public NavMeshAgent m_NavMeshAgent;
    [Header("NPC���������ڕW")]
    public Transform m_Target;
 //   [Header("�A�j���[�V���������N")]
  //  public Animator m_Animator;
    [Header("�A�j���Έڒl")]
    public float m_AnimeSpeed=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //�i�r�̕ϐ����Ȃ��ꍇ�A�����Ń����N����
        if (!m_NavMeshAgent)
            m_NavMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //�ڕW�����݂��Ă���ꍇ
        if (m_Target)
        {
            if(Vector3.Distance(this.transform.position,m_Target.position)>1.0f)
            {
                //�^�[�Q�b�g�܂ł̋������ꃁ�[�g���ȏ�
                m_AnimeSpeed += Time.deltaTime;
                if (m_AnimeSpeed > 1.0f) m_AnimeSpeed = 1.0f;
            }
            else
            {
                //�ꃁ�[�g������
                m_AnimeSpeed -= Time.deltaTime;
                if (m_AnimeSpeed > 0.0f) m_AnimeSpeed = 0.0f;
            }
          //  m_Animator.SetFloat("�ړ�", m_AnimeSpeed);
            //�i�r�ɖڕW���Z�b�g���A��ɒǂ�����������
            m_NavMeshAgent.destination = m_Target.position;
        }
    }
}
