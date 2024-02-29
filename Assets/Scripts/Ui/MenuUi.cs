using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;
    private bool isChoose;

    private void Awake()
    {
        Units.isDemo = true;
    }

    private void Start()
    {
        bestScore.SetText("Best Score : " + DataManager.Instance.bestScore);
    }

    public void LoadMainScene()
    {
        if (isChoose == true)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Need choose hero!");
        }
    }
    public void Exit()
    {
        EditorApplication.ExitPlaymode();
    }

    public void ChooseHero(int value)
    {
        isChoose = true;
        DataManager.Instance.heroInt = value;
    }
}
