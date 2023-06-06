using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalker : MonoBehaviour
{
    public Terrain terrain;         // テレイン
    public GameObject objectPrefab; // 生成するオブジェクトのプレハブ
    public float moveSpeed = 2f;    // 移動速度
    public float rotateSpeed = 180f;    // 回転速度
    public float minMoveTime = 1f;  // 移動時間の最小値
    public float maxMoveTime = 5f;  // 移動時間の最大値
    public float minStopTime = 1f;  // 停止時間の最小値
    public float maxStopTime = 3f;  // 停止時間の最大値

    private Vector3 targetPos;      // 目標位置
    private float currentMoveTime;  // 現在の移動時間
    private float currentStopTime;  // 現在の停止時間

    // 初期化処理
    void Start()
    {
        // 初回の目標位置を設定する
        SetRandomTargetPos();
    }

    // 毎フレーム呼び出される更新処理
    void Update()
    {
        // 目標位置に向かって移動する
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // 目標位置に到着したら、次の目標位置を設定する
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            // 停止時間を設定する
            currentStopTime = Random.Range(minStopTime, maxStopTime);

            // 目標位置を再設定する
            SetRandomTargetPos();
        }

        // 停止時間がある場合は、停止する
        if (currentStopTime > 0)
        {
            currentStopTime -= Time.deltaTime;
            return;
        }

        // 目標位置に向かって回転する
        Vector3 dir = targetPos - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        // 移動時間がある場合は、移動する
        if (currentMoveTime > 0)
        {
            currentMoveTime -= Time.deltaTime;
        }
        else
        {
            // 移動時間が終われば、次の目標位置を設定する
            SetRandomTargetPos();
        }
    }
    // テレインのランダムな位置を目標位置に設定する
    void SetRandomTargetPos()
    {
        // テレインの範囲内のランダムな位置を取得する
        float x = Random.Range(0f, 1f);
        float z = Random.Range(0f, 1f);
        Vector3 randomPos = terrain.transform.position + new Vector3(x * terrain.terrainData.size.x, 0f, z * terrain.terrainData.size.z);

        // テレインの高さを取得して、目標位置を設定する
        float y = terrain.SampleHeight(randomPos);
        targetPos = new Vector3(randomPos.x, y, randomPos.z);

        // 移動時間を設定する
        currentMoveTime = Random.Range(minMoveTime, maxMoveTime);
    }
}
