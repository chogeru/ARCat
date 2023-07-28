using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shooter : MonoBehaviour
{
    [SerializeField]
    private int m_maxShotPower = 10;
    private int m_shotPower;
    public AudioSource m_shotSound;
    public GameObject[] m_catFoodPrefabs;
    public CatFoodManager m_catFoodManager;
    [SerializeField]
    private float m_shotForce;
    [SerializeField]
    private float m_shotTorpe;
    [SerializeField]
    private float m_baseWidth;
    [SerializeField]
    private float m_timer;
    [SerializeField]
    private float m_timeBetweenShot = 1;

    void Start()
    {
        m_shotSound = GetComponent<AudioSource>();
        m_shotPower = m_maxShotPower;
    }

    void Update()
    {
        m_timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && m_timer > m_timeBetweenShot)
        {
            m_timer = 0.0f;
            ChargeShot();
            Shot();
        }
    }

    void ChargeShot()
    {
        // ショットパワーのチャージ処理
        m_shotPower = Mathf.Clamp(m_shotPower + 1, 0, m_maxShotPower);
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
        if (m_catFoodManager.GetCatFoodAmount() <= 0 || m_shotPower <= 0)
            return;

        GameObject catFood = (GameObject)Instantiate(
            SampleCatFood(),
            GetInstantiatePosition(),
            Quaternion.identity);

        Rigidbody candyRigidBody = catFood.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * m_shotForce * m_shotPower);
        candyRigidBody.AddTorque(new Vector3(0, m_shotTorpe * m_shotPower, 0));

        m_shotPower = 0; // ショットを発射したのでパワーをリセット
        m_catFoodManager.ConsumeCatFood(); // キャットフードのストックを消費
        m_shotSound.Play();
    }
}
