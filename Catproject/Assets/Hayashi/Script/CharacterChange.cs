using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    public GameObject[] m_Cats; // 6匹の猫を格納する配列
    private int m_currentIndex = 0; // 現在表示されているキャラクターのインデックス

    private void Start()
    {
        // 最初の猫のみ表示する
        ShowCat(m_currentIndex);
    }

    public void SwitchCat(bool isRight)
    {
        // 左右のボタンによって猫を切り替える
        if (isRight)
        {
            // 右ボタンを押した場合、次の猫へ
            m_currentIndex = (m_currentIndex + 1) % m_Cats.Length;
        }
        else
        {
            // 左ボタンを押した場合、前の猫へ
            m_currentIndex = (m_currentIndex - 1 + m_Cats.Length) % m_Cats.Length; 
        }

        // 現在表示されている猫を非表示にする
        HideAllCat();
        // 新しい猫を表示する
        ShowCat(m_currentIndex);
    }

    private void HideAllCat()
    {
        // 全ての猫を非表示にする
        foreach (GameObject character in m_Cats)
        {
            character.SetActive(false);
        }
    }

    private void ShowCat(int index)
    {
        // 指定されたインデックスの猫を表示する
        m_Cats[index].SetActive(true);
    }
}
