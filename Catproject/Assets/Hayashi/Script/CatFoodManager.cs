using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CatFoodManager : MonoBehaviour
{
    [Header("�L�̉a�̐�")]
    const int DefaultCatFoodAmount = 100;
    //���݂̃L���b�g�t�[�h�̃X�g�b�N��
    public int catFood = DefaultCatFoodAmount;
    [Header("�L�̉a�̐���\������e�L�X�g")]
    public Text catFoodStock; // �L�̉a�c�ʂ�\������e�L�X�g


    public void ConsumeCatFood()
    {
        //�L���b�g�t�[�h��0��葽�������猸�炷
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
        //�e�L�X�g�̕\���̍X�V
        catFoodStock.text = "�L�̉a " + catFood.ToString("F0") + "��";
    }
}
