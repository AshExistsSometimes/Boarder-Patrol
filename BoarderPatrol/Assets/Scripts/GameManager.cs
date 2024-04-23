using System.Collections;
using System.Collections.Generic;
using TMPro;
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

	public int GetScore()
	{
		return score;// Gets the Score Value to be referenced by other scripts
	}

    public void AddScore()
    {
        score++;
		UIText.text = "Score: " + score.ToString();// Changes UI text
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
