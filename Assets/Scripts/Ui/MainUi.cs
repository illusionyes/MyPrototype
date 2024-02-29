using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText;
    private static TextMeshProUGUI _scoreText;
    public static MainUi mainUi;
    public static int scoreUi;
    
    private void Awake()
    {
        mainUi = this;
        Units.isDemo = false;
        _scoreText = scoreText;
    }

    public void LoadMenuScene()
    {
        DataManager.Instance.bestScore = scoreUi;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Spawner.isOver = true;
    }

    public static void SetScoreText(int score)
    {
        if (score < 0)
        {
            Debug.Log("the score cannot be below zero");
        }
        else
        {
            _scoreText.SetText("Score : " + score);
        }
    }
}
