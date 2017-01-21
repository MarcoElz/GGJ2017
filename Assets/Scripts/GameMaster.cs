using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }



    public void GameOver()
    {
        Debug.Log("Game Over");
    }

}
