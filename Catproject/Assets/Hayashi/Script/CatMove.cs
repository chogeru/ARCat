using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public Transform catTransform; // プレイヤーの位置を格納するTransform
    public float moveSpeed = 5f; // 移動速度
    [Range(0, 100)]
    public int Favorability =0;
    private Vector3 randomPosition; // ランダムな位置

    void Start()
    {
        catTransform = GameObject.Find("Player").transform; // プレイヤーオブジェクトのTransformを取得
        CalculateRandomPosition(); // 最初のランダムな位置を計算
    }

    void Update()
    {
        Vector3 direction = randomPosition - transform.position; // 移動方向
        direction.Normalize(); // 方向を正規化

        transform.position += direction * moveSpeed * Time.deltaTime; // 移動処理

        if (Vector3.Distance(transform.position, randomPosition) < 0.5f)
        {
            CalculateRandomPosition(); // ランダムな位置を再計算
        }
        // オブジェクトの回転
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    void CalculateRandomPosition()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI); // ランダムな角度（0から2πまで）
        float randomDistance = Random.Range(0f, 10f); // ランダムな距離（0から30まで）

        Vector3 offset = new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * randomDistance;
        randomPosition = catTransform.position + offset;
    }
}
