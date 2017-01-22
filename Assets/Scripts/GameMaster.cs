using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance;

    public bool isGameOver;

    public int score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    void Start()
    {
        isGameOver = false;
        score = 0;
    }
        
    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    void Update()
    {
        if (isGameOver)
            return;

        //AddScore((int)Time.deltaTime * 1000);
        AddScore((int)Time.deltaTime * 10);
            
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        UIManager.instance.UpdateScore(score);
    }

}
