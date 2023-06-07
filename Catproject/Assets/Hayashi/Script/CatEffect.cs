using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEffect : MonoBehaviour
{
    [Header("弾があたった時のパーティクル")]
    [SerializeField] ParticleSystem hitParticlePrefub;//着弾時演出プレハブ 
    [Header("猫の声")]
    public AudioSource catvoice;                                      
  private void OnCollisionEnter(Collision collision)
    {
        //着弾時に演出自動再生のゲームオブジェクトを生成
        Instantiate(hitParticlePrefub, transform.position, transform.rotation);
        //パーティクルの再生
        hitParticlePrefub.Play();
        //サウンドの再生
        catvoice.Play();
     
    }
}
