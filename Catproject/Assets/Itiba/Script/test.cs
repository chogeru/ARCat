using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class test : MonoBehaviour
{
    [Header("���������N")]
    public Rigidbody m_Rigidbody;

    [Header("�ړ����x")]
    public float m_Speed;
    void Start()
    {
        //���X�N���v�g��ɂ���X�N���v�g�yRigidbody�z����荞��
        m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //���͂œ��͂ɂ��ړ�����
        m_Rigidbody.velocity =
            (Input.GetAxis("Horizontal") * m_Speed) * this.transform.right +
            (Input.GetAxis("Vertical") * m_Speed) * this.transform.forward;
        //�}�E�X��X���ړ��ŉ�]
        this.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
    }
}