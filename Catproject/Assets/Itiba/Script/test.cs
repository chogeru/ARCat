using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class test : MonoBehaviour
{
    [Header("物理リンク")]
    public Rigidbody m_Rigidbody;

    [Header("移動速度")]
    public float m_Speed;
    void Start()
    {
        //同スクリプト上にあるスクリプト【Rigidbody】を取り込む
        m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //一定力で入力による移動処理
        m_Rigidbody.velocity =
            (Input.GetAxis("Horizontal") * m_Speed) * this.transform.right +
            (Input.GetAxis("Vertical") * m_Speed) * this.transform.forward;
        //マウスのX軸移動で回転
        this.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
    }
}