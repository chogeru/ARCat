using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCatMovement : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public float movementSpeed = 0.1f;
    private bool isWalking = false;
    private ARPlane detectedPlane;

    void Update()
    {
        // 平面が検出されていない場合は処理を終了します
        if (detectedPlane == null)
            return;

        // 平面上を歩くアクションのトリガーを取得します
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // 猫が歩くアクションのトリガーを切り替えます
            isWalking = !isWalking;
        }

        // 猫の移動処理
        if (isWalking)
        {
            Vector3 planePosition = new Vector3(detectedPlane.center.x, transform.position.y, detectedPlane.center.z);
            transform.position = Vector3.MoveTowards(transform.position, planePosition, movementSpeed * Time.deltaTime);
        }
    }

    void OnEnable()
    {
        // 平面検出のイベントハンドラを登録します
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        // 平面検出のイベントハンドラを解除します
        planeManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (var plane in eventArgs.added)
        {
            // 最初に検出された平面を取得します
            detectedPlane = plane;
            break;
        }
    }
}
