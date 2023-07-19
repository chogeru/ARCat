using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class CatFoodManager : MonoBehaviour
    {
        [Header("�L�̉a�̐�")]
        const int m_DefaultCatFoodAmount = 10000;
        //���݂̃L���b�g�t�[�h�̃X�g�b�N��
        public int m_CatFood = m_DefaultCatFoodAmount;
        [Header("�L�̉a�̐���\������e�L�X�g")]
        public Text m_CatFoodStock; // �L�̉a�c�ʂ�\������e�L�X�g


        public void ConsumeCatFood()
        {
            //�L���b�g�t�[�h��0��葽�������猸�炷
            if (m_CatFood > 0) m_CatFood--;
        }
        public int GetCatFoodAmount()
        {
            return m_CatFood;
        }
        public void AddCatFood(int amount)
        {
            m_CatFood += amount;
        }
        void Update()
        {
            //�e�L�X�g�̕\���̍X�V
            m_CatFoodStock.text = "�L�̉a " + m_CatFood.ToString("F0") + "��";
        }
    }