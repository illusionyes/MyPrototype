using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUi : MonoBehaviour
{
    private bool isChoose;
    public void LoadMainScene()
    {
        if (isChoose)
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
