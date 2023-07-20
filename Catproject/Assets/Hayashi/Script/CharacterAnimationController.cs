using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 名前の編集以外は基本ノータッチで大丈夫ですby林
/// </summary>
public class CharacterAnimationController : MonoBehaviour
{
    public Animator animator;
    public string[] animationNames; // ランダムに再生するアニメーションの名前を配列で保持

    private float minInterval = 2.0f; // アニメーション切り替えの最小間隔
    private float maxInterval = 5.0f; // アニメーション切り替えの最大間隔

    private bool isAnimating = false; // アニメーション再生中かどうかのフラグ

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

                // ランダムな待ち時間を設定
                float waitTime = Random.Range(minInterval, maxInterval);
                yield return new WaitForSeconds(waitTime);

                // ランダムなアニメーションを再生
                int randomIndex = Random.Range(0, animationNames.Length);
                string randomAnimationName = animationNames[randomIndex];
                animator.SetTrigger(randomAnimationName);

                // アニメーション再生が終わるまで待機
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

                isAnimating = false;
            }

            yield return null;
        }
    }
}
