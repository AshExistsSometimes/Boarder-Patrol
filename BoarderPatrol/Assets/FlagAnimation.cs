using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagAnimation : MonoBehaviour
{

    void Update()
    {
        GetComponent<Animator>().SetTrigger("RaiseFlag");
        Debug.Log("PlayAnimation");
    }
}
