using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimations : MonoBehaviour
{
    [SerializeField,Header("猫のアニメーター")]
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

        // ボタン押下回数によってアニメーションを切り替える
        switch (clickCount)
        {
            case 1:
                animator.SetTrigger("猫の手");
                break;
            case 2:
                animator.SetTrigger("猫の耳");
                break;
           
            default:
                break;
        }
    }
}
