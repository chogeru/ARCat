using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverWave : MonoBehaviour
{
    //ゲームオーバーの波のスピード
    private float gameOverWaveSpeed=10f;
    //ゲームオーバーの波のオブジェクト
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
