using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class CatFoodManager : MonoBehaviour
    {
        [Header("猫の餌の数")]
        const int m_DefaultCatFoodAmount = 10000;
        //現在のキャットフードのストック数
        public int m_CatFood = m_DefaultCatFoodAmount;
        [Header("猫の餌の数を表示するテキスト")]
        public Text m_CatFoodStock; // 猫の餌残量を表示するテキスト


        public void ConsumeCatFood()
        {
            //キャットフードが0より多かったら減らす
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
            //テキストの表示の更新
            m_CatFoodStock.text = "猫の餌 " + m_CatFood.ToString("F0") + "個";
        }
    }