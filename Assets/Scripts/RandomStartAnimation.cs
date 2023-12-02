using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartAnimation : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float randomStartTime = Random.Range(0, stateInfo.length);
        animator.Play(stateInfo.fullPathHash, -1, randomStartTime);
    }
}
