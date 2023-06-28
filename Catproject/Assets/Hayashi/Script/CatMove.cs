using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    public Transform catTransform; // �v���C���[�̈ʒu���i�[����Transform
    public float moveSpeed = 5f; // �ړ����x
    [Range(0, 100)]
    public int Favorability =0;
    private Vector3 randomPosition; // �����_���Ȉʒu

    void Start()
    {
        catTransform = GameObject.Find("Player").transform; // �v���C���[�I�u�W�F�N�g��Transform���擾
        CalculateRandomPosition(); // �ŏ��̃����_���Ȉʒu���v�Z
    }

    void Update()
    {
        Vector3 direction = randomPosition - transform.position; // �ړ�����
        direction.Normalize(); // �����𐳋K��

        transform.position += direction * moveSpeed * Time.deltaTime; // �ړ�����

        if (Vector3.Distance(transform.position, randomPosition) < 0.5f)
        {
            CalculateRandomPosition(); // �����_���Ȉʒu���Čv�Z
        }
        // �I�u�W�F�N�g�̉�]
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    void CalculateRandomPosition()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI); // �����_���Ȋp�x�i0����2�΂܂Łj
        float randomDistance = Random.Range(0f, 10f); // �����_���ȋ����i0����30�܂Łj

        Vector3 offset = new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * randomDistance;
        randomPosition = catTransform.position + offset;
    }
}
