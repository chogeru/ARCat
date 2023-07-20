using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cat
{
    public class CatFood : MonoBehaviour
    {
        public GameObject particlePrefab; // パーティクルのPrefabを指定

        public float deleteTime = 3.0f;
        // Start is called before the first frame update
        void Awake()
        {
            Invoke("GenerateParticle", deleteTime);
            //CatFoodを削除する
            Destroy(gameObject, deleteTime);
        }
        void OnCollisionEnter(Collision collision)
        {
            // 衝突した相手にCatタグが付いているとき
            if (collision.gameObject.tag == "Cat")
            {
                //消える
                Destroy(gameObject);
            }
        }
        void GenerateParticle()
        {
            // パーティクルを生成して再生
            if (particlePrefab != null)
            {
                Instantiate(particlePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}