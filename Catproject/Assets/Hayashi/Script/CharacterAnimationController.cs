using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���O�̕ҏW�ȊO�͊�{�m�[�^�b�`�ő��v�ł�by��
/// </summary>
public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator;
    public string[] animationNames; // �����_���ɍĐ�����A�j���[�V�����̖��O��z��ŕێ�

    private float minInterval = 2.0f; // �A�j���[�V�����؂�ւ��̍ŏ��Ԋu
    private float maxInterval = 5.0f; // �A�j���[�V�����؂�ւ��̍ő�Ԋu

    private bool isAnimating = false; // �A�j���[�V�����Đ������ǂ����̃t���O

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayRandomAnimation());
    }

    IEnumerator PlayRandomAnimation()
    {
        while (true)
        {
            if (!isAnimating)
            {
                isAnimating = true;

                // �����_���ȑ҂����Ԃ�ݒ�
                float waitTime = Random.Range(minInterval, maxInterval);
                yield return new WaitForSeconds(waitTime);

                // �����_���ȃA�j���[�V�������Đ�
                int randomIndex = Random.Range(0, animationNames.Length);
                string randomAnimationName = animationNames[randomIndex];
                animator.SetTrigger(randomAnimationName);

                // �A�j���[�V�����Đ����I���܂őҋ@
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

                isAnimating = false;
            }

            yield return null;
        }
    }
}
