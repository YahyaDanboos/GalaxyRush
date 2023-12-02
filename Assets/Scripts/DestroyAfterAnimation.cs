using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        StartCoroutine(WaitAndDestroy(stateInfo.length));
    }

    IEnumerator WaitAndDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
