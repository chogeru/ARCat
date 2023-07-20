using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [RequireComponent(typeof(Animator))]
    public class CatMove : MonoBehaviour
    {
        [Header("�v���C���[�̈ʒu������")]
        public Transform m_CatTransform; // �v���C���[�̈ʒu���i�[����Transform

        [SerializeField,Header("�L�̈ړ����x")]
        private float m_MoveSpeed = 5f; // �ړ����x

        [Range(0, 100),SerializeField]
        private int m_Favorability = 0;//�D���x

        private Vector3 m_RandomPosition; // �����_���Ȉʒu

        [Header("�L�̐}�Ӊ��"),SerializeField]
        public bool m_ZukanKaihou = false;
        private float m_MinHeightOffset = -1.0f; // �L���v���C���[���Ⴂ�ʒu�ɍs�����Ƃ𐧌�����I�t�Z�b�g
    void Start()
        {
            m_CatTransform = GameObject.Find("Player").transform; // �v���C���[�I�u�W�F�N�g��Transform���擾
            CalculateRandomPosition(); // �ŏ��̃����_���Ȉʒu���v�Z
        }

    void Update()
    {
        Vector3 direction = m_RandomPosition - transform.position; // �ړ�����
        direction.Normalize(); // �����𐳋K��

        transform.position += direction * m_MoveSpeed * Time.deltaTime; // �ړ�����

        if (Vector3.Distance(transform.position, m_RandomPosition) < 0.5f)
        {
            CalculateRandomPosition(); // �����_���Ȉʒu���Čv�Z
        }
        // �I�u�W�F�N�g�̉�]
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        if (m_Favorability <= 15)
        {
            m_ZukanKaihou = true;
        }
      
    }
        void CalculateRandomPosition()
        {
            float randomAngle = Random.Range(0f, 2f * Mathf.PI); // �����_���Ȋp�x�i0����2�΂܂Łj
            float randomDistance = Random.Range(0f, 18f); // �����_���ȋ����i0����30�܂Łj

            Vector3 offset = new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * randomDistance;
            m_RandomPosition = m_CatTransform.position + offset;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("CatFood"))
            {
            m_Favorability++;
            }
        }
    }