using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatFoodManager : MonoBehaviour
{
    [Header("猫の餌の数")]
    const int DefaultCatFoodAmount = 100;
    //現在のキャットフードのストック数
    public int catFood = DefaultCatFoodAmount;
    [Header("猫の餌の数を表示するテキスト")]
    public Text catFoodStock; // 猫の餌残量を表示するテキスト


    public void ConsumeCatFood()
    {
        //キャットフードが0より多かったら減らす
        if (catFood > 0) catFood--;
    }
    public int GetCatFoodAmount()
    {
        return catFood;
    }
    public void AddCatFood(int amount)
    {
        catFood += amount;
    }
    void Update()
    {
        //テキストの表示の更新
        catFoodStock.text = "猫の餌 " + catFood.ToString("F0") + "個";
    }
}
