using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimation : MonoBehaviour
{
    public float AnimPlayTime = 0f;
    Animator flagAnim;
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(AnimPlayTime);

        flagAnim = this.GetComponent<Animator>();//.SetTrigger("RaiseFlag");
        flagAnim.SetTrigger("RaiseFlag");

        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FlagBob"))
        {
            Debug.Log("should be animating flag");
        }
    }

    void Start()
    {
        StartCoroutine(Delay());
        Debug.Log("Animation Script started");
    }
}
