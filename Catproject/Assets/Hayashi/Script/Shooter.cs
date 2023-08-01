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
            // �V���b�g�p���[�𑝂₷
            m_shotForce += Time.deltaTime * m_shotPowerIncreaseRate;
            // �ő�V���b�g�p���[�𒴂��Ȃ��悤�ɐ���
            m_shotForce = Mathf.Clamp(m_shotForce, 0f, m_maxShotPower);
            // �X���C�_�[�̒l���E�ɓ�����
            m_slider.value += Time.deltaTime * m_speed;
            m_ChargeSE.SetActive(true);
        }
        else
        {
            m_ChargeSE.SetActive(false);
            // �{�^���������ꂽ��`���[�W���I������
            m_isCharging = false;
            // �{�^���������ꂽ��X���C�_�[�������l�ɖ߂�
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
        //�v���n�u����CatFood�I�u�W�F�N�g�𐶐�
        GameObject CatFood = (GameObject)Instantiate(
            SampleCatFood(),
            GetInstantiatePosition(),
            Quaternion.identity);
        //CatFood�I�u�W�F�N�g��Rigidbody���������͂Ɖ�]��������
        Rigidbody candyRigidBody = CatFood.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * m_shotForce);
        candyRigidBody.AddTorque(new Vector3(0, m_shotTorpe, 0));
        //CatFood�̃X�g�b�N������
        m_shotSound.Play();

    }
    // �V���b�g�{�^���������ꂽ���ɌĂ΂�郁�\�b�h
    public void OnShotButtonPressed()
    {
        isShotButtonPressed = true;
    }

    // �V���b�g�{�^���������ꂽ���ɌĂ΂�郁�\�b�h
    public void OnShotButtonReleased()
    {
        isShotButtonPressed = false;
    }

    
}
