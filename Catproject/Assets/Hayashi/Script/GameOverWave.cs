using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWave : MonoBehaviour
{
    //�Q�[���I�[�o�[�̔g�̃X�s�[�h
    private float gameOverWaveSpeed=10f;
    //�Q�[���I�[�o�[�̔g�̃I�u�W�F�N�g
    private GameObject gameOverWaveObject;
    void Start()
    {
        //
        gameOverWaveObject = GameObject.Find("GameOverWave");

    }

    void Update()
    {
        
    }
}
