using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEffect : MonoBehaviour
{
    [Header("�e�������������̃p�[�e�B�N��")]
    [SerializeField] ParticleSystem hitParticlePrefub;//���e�����o�v���n�u 
    [Header("�L�̐�")]
    public AudioSource catvoice;                                      
  private void OnCollisionEnter(Collision collision)
    {
        //���e���ɉ��o�����Đ��̃Q�[���I�u�W�F�N�g�𐶐�
        Instantiate(hitParticlePrefub, transform.position, transform.rotation);
        //�p�[�e�B�N���̍Đ�
        hitParticlePrefub.Play();
        //�T�E���h�̍Đ�
        catvoice.Play();
     
    }
}
