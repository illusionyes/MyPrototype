using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set;}
    public int heroInt;
    private int _bestScore;
    public int bestScore
    {
        get { return _bestScore; }
        set {
            if (value < 0.0f)
            {
                Debug.Log("the score cannot be below zero");
            }
            else
            {
                _bestScore = value;
            }
        }
    }
   
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
