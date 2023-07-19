using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpown : MonoBehaviour
{
    public GameObject[] catPrefabs; // �X�|�[��������Cat�I�u�W�F�N�g�̃v���n�u�z��
    public Transform playerTransform; // �v���C���[��Transform
    public float spawnRadius = 5f; // �X�|�[���͈͂̔��a

    private void Update()
    {
        // Cat�^�O�̃I�u�W�F�N�g���擾
        GameObject[] cats = GameObject.FindGameObjectsWithTag("Cat");

        // Cat�I�u�W�F�N�g��2�C�����̏ꍇ�ɃX�|�[��������
        if (cats.Length < 2)
        {
            SpawnCat();
        }
    }

    private void SpawnCat()
    {
        // �v���C���[�̈ʒu�𒆐S�Ƀ����_���Ȉʒu���v�Z
        Vector3 spawnPosition = Random.insideUnitSphere * spawnRadius + playerTransform.position;
        spawnPosition.y = playerTransform.position.y; // Y���W���v���C���[�Ɠ����ɂ���

        // �����_���ɔL�̃v���n�u��I��
        GameObject catPrefab = catPrefabs[Random.Range(0, catPrefabs.Length)];

        // Cat�I�u�W�F�N�g���X�|�[��������
        Instantiate(catPrefab, spawnPosition, Quaternion.identity);
    }
}

