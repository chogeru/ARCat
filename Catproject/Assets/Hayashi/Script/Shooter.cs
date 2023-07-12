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
    private float timer;//タイマー
    [SerializeField]
    private float timeBetweenShot = 1;//弾の発射感覚
    void Start()
    {
        shotSound = GetComponent<AudioSource>();    
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;//タイマー作動
        if (Input.GetButton("Fire1") && timer > timeBetweenShot)
            {
            //タイマーの時間をもとに戻す
            timer = 0.0f;
            Shot(); 

        }

        }
    //CatFoodのプレハブからランダムに一つ選ぶ
    GameObject SampleCatFood()
    {
        int index = Random.Range(0, catFoodPrefabs.Length);
        return catFoodPrefabs[index];
    }

    Vector3 GetInstantiatePosition()
    {
        //画面のサイズとInputの割合からキャンディーの生成ポジションを計算
        float x = baseWidth *
            (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);

    }
    public void Shot()
    {
        //CatFoodを生成できる条件外ならShotしない
        if (catFoodManager.GetCatFoodAmount() <= 0) return;
        if (shotPower <= 0) return;
        //プレハブからCatFoodオブジェクトを生成
        GameObject CatFood = (GameObject)Instantiate(
            SampleCatFood(),
            GetInstantiatePosition(),
            Quaternion.identity);
        //CatFoodオブジェクトのRigidbodyを所得し力と回転を加える
        Rigidbody candyRigidBody = CatFood.GetComponent < Rigidbody > ();
        candyRigidBody.AddForce(transform.forward * shotForce);
        candyRigidBody.AddTorque(new Vector3(0, shotTorpe, 0));
        //CatFoodのストックを消費
        catFoodManager.ConsumeCatFood();
        //サウンドを再生
        shotSound.Play();
    }
 
}
