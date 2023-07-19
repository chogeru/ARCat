using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppreciationCatRote : MonoBehaviour
{
    private Vector2 touchStartPos; // �^�b�`�J�n�ʒu
    private bool isRotating; // ��]�����ǂ����������t���O

    private void Update()
    {
        // �^�b�`�̌��o
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // �^�b�`���J�n���ꂽ�ʒu���L�^
                    touchStartPos = touch.position;
                    isRotating = true;
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        // �^�b�`���ړ����������ɉ����ăI�u�W�F�N�g����]������
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
