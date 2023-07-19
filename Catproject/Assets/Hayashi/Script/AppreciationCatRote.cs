using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppreciationCatRote : MonoBehaviour
{
    private Vector2 touchStartPos; // タッチ開始位置
    private bool isRotating; // 回転中かどうかを示すフラグ

    private void Update()
    {
        // タッチの検出
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // タッチが開始された位置を記録
                    touchStartPos = touch.position;
                    isRotating = true;
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        // タッチが移動した距離に応じてオブジェクトを回転させる
                        Vector2 swipeDelta = touch.position - touchStartPos;
                        float rotationAmount = swipeDelta.x * 0.5f;
                        transform.Rotate(Vector3.up, rotationAmount, Space.World);
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }
}
