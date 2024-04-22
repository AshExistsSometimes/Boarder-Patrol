using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    public TextMeshProUGUI UIText;

    public int score = 0;
    public bool LevelCompleted = false;

    public void AddScore()
    {
        score++;
        UIText.text = "Score: " + score.ToString();
    }

    private void Update()
    {
        if (LevelCompleted == true)
        {
            LevelCompleted = false;
            LoadNextScene();
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
