using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [RequireComponent(typeof(Animator))]
    public class CatMove : MonoBehaviour
    {
        [Header("プレイヤーの位置を所得")]
        public Transform m_CatTransform; // プレイヤーの位置を格納するTransform

        [SerializeField,Header("猫の移動速度")]
        private float m_MoveSpeed = 5f; // 移動速度

        [Range(0, 100),SerializeField]
        private int m_Favorability = 0;//好感度

        private Vector3 m_RandomPosition; // ランダムな位置

        [Header("猫の図鑑解放"),SerializeField]
        public bool m_ZukanKaihou = false;
        private float m_MinHeightOffset = -1.0f; // 猫がプレイヤーより低い位置に行くことを制限するオフセット
    void Start()
        {
            m_CatTransform = GameObject.Find("Player").transform; // プレイヤーオブジェクトのTransformを取得
            CalculateRandomPosition(); // 最初のランダムな位置を計算
        }

    void Update()
    {
        Vector3 direction = m_RandomPosition - transform.position; // 移動方向
        direction.Normalize(); // 方向を正規化

        transform.position += direction * m_MoveSpeed * Time.deltaTime; // 移動処理

        if (Vector3.Distance(transform.position, m_RandomPosition) < 0.5f)
        {
            CalculateRandomPosition(); // ランダムな位置を再計算
        }
        // オブジェクトの回転
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        if (m_Favorability <= 15)
        {
            m_ZukanKaihou = true;
        }
      
    }
        void CalculateRandomPosition()
        {
            float randomAngle = Random.Range(0f, 2f * Mathf.PI); // ランダムな角度（0から2πまで）
            float randomDistance = Random.Range(0f, 18f); // ランダムな距離（0から30まで）

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