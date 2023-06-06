using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatFoodManager : MonoBehaviour
{
    const int DefaultCatFoodAmount = 100;
    //���݂̃L���b�g�t�[�h�̃X�g�b�N��
    public int catFood = DefaultCatFoodAmount;
    public Text catFoodStock; // �L�̉a�c�ʂ�\������e�L�X�g
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
        catFoodStock.text = "�L�̉a " + catFood.ToString("F0") + "��";
    }
}
