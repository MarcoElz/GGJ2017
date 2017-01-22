using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public GameObject backgroundCamera;

    public static GameMaster instance;

    public bool isGameOver;

    public int score;

    public int highscore;

    private bool isBoss;
    private GameObject player;

    private bool gameWin;


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
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        isBoss = false;
        player = GameObject.FindGameObjectWithTag("Player");
        gameWin = false;
    }
        
    public void GameOver()
    {
        Debug.Log("Game Over");
        GameFinish("Game Over");

    }

    private void GameWin()
    {
        GameFinish("Win!!");
    }

    private void GameFinish(string gameStatus)
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        LevelManager.instance.Stop();
        UIManager.instance.ShowGameOver(gameStatus);
        Time.timeScale = 0;
    }


    void FixedUpdate()
    {
        if (isGameOver)
            return;
        
        AddScore(1);

        float posX = backgroundCamera.transform.position.x;
        if (posX > 20 && !isBoss)
        {
            isBoss = true;
            FinishFirstRound();
        }
        else if (posX > 49 && !gameWin)
        {
            gameWin = true;
            GameWin();
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        score = Mathf.Clamp(score, 0, 9999999);
        UIManager.instance.UpdateScore(score);
    }

    public void FinishFirstRound()
    {
        player.GetComponent<Submarine>().canTakeDamage = false;
        LevelManager.instance.BossFight();
    }

}
