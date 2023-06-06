using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticlePrefub;//着弾時演出プレハブ 
                                                      
  private void OnCollisionEnter(Collision collision)
    {
        //着弾時に演出自動再生のゲームオブジェクトを生成
        Instantiate(hitParticlePrefub, transform.position, transform.rotation);
        hitParticlePrefub.Play();
     
    }
}
