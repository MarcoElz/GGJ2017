﻿using UnityEngine;
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


    void FixedUpdate()
    {
        if (isGameOver)
            return;
        
        AddScore(1);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        score = Mathf.Clamp(score, 0, 9999999);
        UIManager.instance.UpdateScore(score);
    }

}
