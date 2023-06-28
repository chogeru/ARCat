using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Test : MonoBehaviour
{
    private void Awake()
    {
        TryGetComponent(out _arRaycastManager);
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                // 画面のタップされた位置からRaycastを飛ばす
                if (_arRaycastManager.Raycast(touch.position, _hitResults))
                {
                    _transform.position = _hitResults[0].pose.position;
                }
            }
        }
    }

    private readonly List<ARRaycastHit> _hitResults = new List<ARRaycastHit>();
    private ARRaycastManager _arRaycastManager = null;

    // 再配置したいTransform
    [SerializeField]
    private Transform _transform = null;
}

