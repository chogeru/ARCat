using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Animation : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g�擾
        animator = GetComponent<Animator>();

    }

    void Update()
   {
       
        
   }

}

