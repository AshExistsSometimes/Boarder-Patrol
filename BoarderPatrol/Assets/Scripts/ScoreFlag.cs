using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreFlag : MonoBehaviour
{
    public TextMeshPro ScoreDisplay; 

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Flag Passed!");
            GameManager.Instance.AddScore();

            string ScoreDisplay = "score";
            ScoreDisplay += GameManager.Instance.GetScore().ToString();

            GetComponent<SFXPlayer>().PlaySFX();

            StartCoroutine(DelayedDestroy());
        }
    }
}
