using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreFlag : MonoBehaviour
{
    public TextMeshPro ScoreDisplay; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Flag Passed!");
            GameManager.Instance.AddScore();

            string ScoreDisplay = "score";
            ScoreDisplay += GameManager.Instance.GetScore().ToString();

            //ScoreDisplay.text = "grdfdfgsdf";//scoreLabel;//GameManager.Instance.GetScore().ToString());
            
            
            
            
            Destroy(gameObject);
        }
    }
}
