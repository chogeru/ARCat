using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpown : MonoBehaviour
{
    public GameObject[] catPrefabs; // スポーンさせるCatオブジェクトのプレハブ配列
    public Transform playerTransform; // プレイヤーのTransform
    public float spawnRadius = 5f; // スポーン範囲の半径

    private void Update()
    {
        // Catタグのオブジェクトを取得
        GameObject[] cats = GameObject.FindGameObjectsWithTag("Cat");

        // Catオブジェクトが2匹未満の場合にスポーンさせる
        if (cats.Length < 2)
        {
            SpawnCat();
        }
    }

    private void SpawnCat()
    {
        // プレイヤーの位置を中心にランダムな位置を計算
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + playerTransform.position;
        spawnPosition.y = playerTransform.position.y; // Y座標をプレイヤーと同じにする

        // ランダムに猫のプレハブを選択
        GameObject catPrefab = catPrefabs[Random.Range(0, catPrefabs.Length)];

        // Catオブジェクトをスポーンさせる
        Instantiate(catPrefab, spawnPosition, Quaternion.identity);
    }
}

