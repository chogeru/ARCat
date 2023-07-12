using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shooter : MonoBehaviour
{
    [SerializeField]
    const int MaxShotPower=10;
    int shotPower = MaxShotPower;
    public AudioSource shotSound;
    public GameObject[] catFoodPrefabs;
    //public Transform catFoodParentTransform;
    public CatFoodManager catFoodManager;
    [SerializeField]
    private float shotForce;
    [SerializeField]
    private float shotTorpe;
    [SerializeField]
    private float baseWidth;
    [SerializeField]
    private float timer;//�^�C�}�[
    [SerializeField]
    private float timeBetweenShot = 1;//�e�̔��ˊ��o
    void Start()
    {
        shotSound = GetComponent<AudioSource>();    
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;//�^�C�}�[�쓮
        if (Input.GetButton("Fire1") && timer > timeBetweenShot)
            {
            //�^�C�}�[�̎��Ԃ����Ƃɖ߂�
            timer = 0.0f;
            Shot(); 

        }

        }
    //CatFood�̃v���n�u���烉���_���Ɉ�I��
    GameObject SampleCatFood()
    {
        int index = Random.Range(0, catFoodPrefabs.Length);
        return catFoodPrefabs[index];
    }

    Vector3 GetInstantiatePosition()
    {
        //��ʂ̃T�C�Y��Input�̊�������L�����f�B�[�̐����|�W�V�������v�Z
        float x = baseWidth *
            (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);

    }
    public void Shot()
    {
        //CatFood�𐶐��ł�������O�Ȃ�Shot���Ȃ�
        if (catFoodManager.GetCatFoodAmount() <= 0) return;
        if (shotPower <= 0) return;
        //�v���n�u����CatFood�I�u�W�F�N�g�𐶐�
        GameObject CatFood = (GameObject)Instantiate(
            SampleCatFood(),
            GetInstantiatePosition(),
            Quaternion.identity);
        //CatFood�I�u�W�F�N�g��Rigidbody���������͂Ɖ�]��������
        Rigidbody candyRigidBody = CatFood.GetComponent < Rigidbody > ();
        candyRigidBody.AddForce(transform.forward * shotForce);
        candyRigidBody.AddTorque(new Vector3(0, shotTorpe, 0));
        //CatFood�̃X�g�b�N������
        catFoodManager.ConsumeCatFood();
        //�T�E���h���Đ�
        shotSound.Play();
    }
 
}
