using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimations : MonoBehaviour
{
    [SerializeField,Header("�L�̃A�j���[�^�[")]
    public Animator animator;
    private int clickCount = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (clickCount <= 10)
        {
            clickCount = 0; 
        }
    }
    public void OnButtonClick()
    {
        clickCount++;

        // �{�^�������񐔂ɂ���ăA�j���[�V������؂�ւ���
        switch (clickCount)
        {
            case 1:
                animator.SetTrigger("�L�̎�");
                break;
            case 2:
                animator.SetTrigger("�L�̎�");
                break;
           
            default:
                break;
        }
    }
}
