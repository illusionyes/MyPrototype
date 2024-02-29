using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText;
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Spawner.isOver = true;
    }
}
