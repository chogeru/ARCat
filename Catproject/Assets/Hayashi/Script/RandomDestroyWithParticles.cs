using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestroyWithParticles : MonoBehaviour
{
    public GameObject particlePrefab; // パーティクルのプレハブ
    public AudioClip destroySound; // オブジェクトが消滅する際のサウンド
    private float minDuration = 30f; // 30分（60秒）
    private float maxDuration = 60f; // 1分（180秒）

    private float timeToDestroy;
    private bool isDestroyed;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSourceコンポーネントがアタッチされていない場合は、新たに追加する
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (destroySound != null)
        {
            audioSource.clip = destroySound;
        }

        // ランダムな時間を計算し、オブジェクトを消滅させる予定時刻を設定する
        timeToDestroy = Time.time + Random.Range(minDuration, maxDuration);
    }

    private void Update()
    {
        if (!isDestroyed && Time.time >= timeToDestroy)
        {
            // パーティクルを出す
            SpawnParticles();
            // サウンドを再生する
            if (destroySound != null)
            {
                audioSource.Play();
            }
            // オブジェクトを消滅させる
            Destroy(gameObject);
            isDestroyed = true;
        }
    }

    private void SpawnParticles()
    {
        if (particlePrefab != null)
        {
            // パーティクルのプレハブからインスタンスを生成
            GameObject particles = Instantiate(particlePrefab, transform.position, Quaternion.identity);

            // パーティクルが完了したら、パーティクルを破棄
            ParticleSystem ps = particles.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                Destroy(particles, ps.main.duration);
            }
            else
            {
                // ParticleSystemコンポーネントが見つからなかった場合は、パーティクルが再生し終わったら破棄する
                ParticleSystem.MainModule main = particles.GetComponent<ParticleSystem>().main;
                Destroy(particles, main.duration);
            }
        }
    }
}
