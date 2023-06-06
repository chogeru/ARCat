using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatFoodManager : MonoBehaviour
{
    const int DefaultCatFoodAmount = 100;
    //現在のキャットフードのストック数
    public int catFood = DefaultCatFoodAmount;
    public Text catFoodStock; // 猫の餌残量を表示するテキスト
    public void ConsumeCatFood()
    {
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
        catFoodStock.text = "猫の餌 " + catFood.ToString("F0") + "個";
    }
}
