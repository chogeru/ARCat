using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFood : MonoBehaviour
{
    
    public float deleteTime = 3.0f;
    // Start is called before the first frame update
    void Awake()
    {
        //CatFood���폜����
        Destroy(gameObject,deleteTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        // �Փ˂��������Cat�^�O���t���Ă���Ƃ�
        if (collision.gameObject.tag == "Cat")
        {
         
            //������
            Destroy(gameObject);
        }
    }
}
