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
        // ���ʂ����o����Ă��Ȃ��ꍇ�͏������I�����܂�
        if (detectedPlane == null)
            return;

        // ���ʏ������A�N�V�����̃g���K�[���擾���܂�
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // �L�������A�N�V�����̃g���K�[��؂�ւ��܂�
            isWalking = !isWalking;
        }

        // �L�̈ړ�����
        if (isWalking)
        {
            Vector3 planePosition = new Vector3(detectedPlane.center.x, transform.position.y, detectedPlane.center.z);
            transform.position = Vector3.MoveTowards(transform.position, planePosition, movementSpeed * Time.deltaTime);
        }
    }

    void OnEnable()
    {
        // ���ʌ��o�̃C�x���g�n���h����o�^���܂�
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        // ���ʌ��o�̃C�x���g�n���h�����������܂�
        planeManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (var plane in eventArgs.added)
        {
            // �ŏ��Ɍ��o���ꂽ���ʂ��擾���܂�
            detectedPlane = plane;
            break;
        }
    }
}
