using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticlePrefub;//���e�����o�v���n�u 
    public AudioSource catvoice;                                      
  private void OnCollisionEnter(Collision collision)
    {
        //���e���ɉ��o�����Đ��̃Q�[���I�u�W�F�N�g�𐶐�
        Instantiate(hitParticlePrefub, transform.position, transform.rotation);
        hitParticlePrefub.Play();
        catvoice.Play();
     
    }
}
