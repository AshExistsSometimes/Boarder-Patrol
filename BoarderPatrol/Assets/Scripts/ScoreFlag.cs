using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFlag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Debug.Log("Flag Passed!");
            GameManager.Instance.AddScore();
        Destroy(gameObject);
    }
}
