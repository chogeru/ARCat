using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatWalker : MonoBehaviour
{
    public Terrain terrain;         // �e���C��
    public GameObject objectPrefab; // ��������I�u�W�F�N�g�̃v���n�u
    public float moveSpeed = 2f;    // �ړ����x
    public float rotateSpeed = 180f;    // ��]���x
    public float minMoveTime = 1f;  // �ړ����Ԃ̍ŏ��l
    public float maxMoveTime = 5f;  // �ړ����Ԃ̍ő�l
    public float minStopTime = 1f;  // ��~���Ԃ̍ŏ��l
    public float maxStopTime = 3f;  // ��~���Ԃ̍ő�l

    private Vector3 targetPos;      // �ڕW�ʒu
    private float currentMoveTime;  // ���݂̈ړ�����
    private float currentStopTime;  // ���݂̒�~����

    // ����������
    void Start()
    {
        // ����̖ڕW�ʒu��ݒ肷��
        SetRandomTargetPos();
    }

    // ���t���[���Ăяo�����X�V����
    void Update()
    {
        // �ڕW�ʒu�Ɍ������Ĉړ�����
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // �ڕW�ʒu�ɓ���������A���̖ڕW�ʒu��ݒ肷��
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            // ��~���Ԃ�ݒ肷��
            currentStopTime = Random.Range(minStopTime, maxStopTime);

            // �ڕW�ʒu���Đݒ肷��
            SetRandomTargetPos();
        }

        // ��~���Ԃ�����ꍇ�́A��~����
        if (currentStopTime > 0)
        {
            currentStopTime -= Time.deltaTime;
            return;
        }

        // �ڕW�ʒu�Ɍ������ĉ�]����
        Vector3 dir = targetPos - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        // �ړ����Ԃ�����ꍇ�́A�ړ�����
        if (currentMoveTime > 0)
        {
            currentMoveTime -= Time.deltaTime;
        }
        else
        {
            // �ړ����Ԃ��I���΁A���̖ڕW�ʒu��ݒ肷��
            SetRandomTargetPos();
        }
    }
    // �e���C���̃����_���Ȉʒu��ڕW�ʒu�ɐݒ肷��
    void SetRandomTargetPos()
    {
        // �e���C���͈͓̔��̃����_���Ȉʒu���擾����
        float x = Random.Range(0f, 1f);
        float z = Random.Range(0f, 1f);
        Vector3 randomPos = terrain.transform.position + new Vector3(x * terrain.terrainData.size.x, 0f, z * terrain.terrainData.size.z);

        // �e���C���̍������擾���āA�ڕW�ʒu��ݒ肷��
        float y = terrain.SampleHeight(randomPos);
        targetPos = new Vector3(randomPos.x, y, randomPos.z);

        // �ړ����Ԃ�ݒ肷��
        currentMoveTime = Random.Range(minMoveTime, maxMoveTime);
    }
}
