using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set;}
    private int _bestScore;
    private int _heroInt;
    public int heroInt
    {
        get { return _heroInt;}
        set
        {
            if (value < 0)
            {
                Debug.Log("error");
            }
            else
            {
                _heroInt = value;
            }
        }
    }

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
