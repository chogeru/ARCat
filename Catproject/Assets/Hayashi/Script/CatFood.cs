using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cat
{
    public class CatFood : MonoBehaviour
    {
        public GameObject particlePrefab; // �p�[�e�B�N����Prefab���w��

        public float deleteTime = 3.0f;
        // Start is called before the first frame update
        void Awake()
        {
            Invoke("GenerateParticle", deleteTime);
            //CatFood���폜����
            Destroy(gameObject, deleteTime);
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
        void GenerateParticle()
        {
            // �p�[�e�B�N���𐶐����čĐ�
            if (particlePrefab != null)
            {
                Instantiate(particlePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}