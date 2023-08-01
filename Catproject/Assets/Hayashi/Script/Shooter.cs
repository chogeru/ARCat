using Cat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class Shooter : MonoBehaviour
{
    [SerializeField]
    private float m_maxShotPower = 1000;
    [SerializeField]
    private float m_shotPower;
    public float m_shotPowerIncreaseRate = 150f; 
    private bool m_isCharging=false;
    public AudioSource m_shotSound;
    public GameObject m_ChargeSE;
    public GameObject[] m_catFoodPrefabs;
    public CatFoodManager m_catFoodManager;
    [SerializeField]
    private float m_shotForce;
    [SerializeField]
    private float m_minForce;
    [SerializeField]
    private float m_shotTorpe;
    [SerializeField]
    private float m_baseWidth;
    [SerializeField]
    private float m_timer;
    [SerializeField]
    private float m_timeBetweenShot = 1;
    public Slider m_slider;
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private float m_sliderbackspeed;
    private bool isShotButtonPressed = false;


    void Start()
    {
        m_shotSound = GetComponent<AudioSource>();
        m_shotPower = m_maxShotPower;
    }

    void Update()
    {
        m_timer += Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            m_isCharging = true;
            // ショットパワーを増やす
            m_shotForce += Time.deltaTime * m_shotPowerIncreaseRate;
            // 最大ショットパワーを超えないように制限
            m_shotForce = Mathf.Clamp(m_shotForce, 0f, m_maxShotPower);
            // スライダーの値を右に動かす
            m_slider.value += Time.deltaTime * m_speed;
            m_ChargeSE.SetActive(true);
        }
        else
        {
            m_ChargeSE.SetActive(false);
            // ボタンが離されたらチャージを終了する
            m_isCharging = false;
            // ボタンが離されたらスライダーを初期値に戻す
            m_slider.value = Mathf.Lerp(m_slider.value, m_slider.minValue, Time.deltaTime * m_sliderbackspeed);

        }
        if (Input.GetButtonUp("Fire1") && m_timer > m_timeBetweenShot)
        {
            m_timer = 0.0f;
            Shot();
            m_shotForce = m_minForce;
        }
    }


    GameObject SampleCatFood()
    {
        int index = Random.Range(0, m_catFoodPrefabs.Length);
        return m_catFoodPrefabs[index];
    }

    Vector3 GetInstantiatePosition()
    {
        float x = m_baseWidth * (Input.mousePosition.x / Screen.width) - (m_baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }

    public void Shot()
    {
        if (m_catFoodManager.GetCatFoodAmount() <= 0) return;
        if (m_shotPower <= 0) return;
        //プレハブからCatFoodオブジェクトを生成
        GameObject CatFood = (GameObject)Instantiate(
            SampleCatFood(),
            GetInstantiatePosition(),
            Quaternion.identity);
        //CatFoodオブジェクトのRigidbodyを所得し力と回転を加える
        Rigidbody candyRigidBody = CatFood.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * m_shotForce);
        candyRigidBody.AddTorque(new Vector3(0, m_shotTorpe, 0));
        //CatFoodのストックを消費
        m_shotSound.Play();

    }
    // ショットボタンが押された時に呼ばれるメソッド
    public void OnShotButtonPressed()
    {
        isShotButtonPressed = true;
    }

    // ショットボタンが離された時に呼ばれるメソッド
    public void OnShotButtonReleased()
    {
        isShotButtonPressed = false;
    }

    
}
