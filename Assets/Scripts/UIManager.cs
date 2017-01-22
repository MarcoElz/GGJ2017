using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
   
    public static UIManager instance;

    public GameObject gameOverStuff;
    public GameObject blackScreen;

    public Image healthBar;
    public Text score;

    public Text highScore;
    public Text lastScore;

    void Start()
    {
        gameOverStuff.SetActive(false);
        UpdateHealth(100);

        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateHealth(int actualHealth)
    {
        healthBar.fillAmount = actualHealth / 100.0f;
    }

    public void UpdateScore(int actualScore)
    {
        score.text = actualScore.ToString("0000000");
    }

    public void ShowGameOver()
    {
        Animator blackScreenAnimator = blackScreen.GetComponent<Animator>();
        blackScreenAnimator.SetTrigger("FadeIn");
        highScore.text = "Highscore: " + GameMaster.instance.highscore.ToString("0000000");
        lastScore.text = "Your score: " + score.text;
        //TimeScale
        Time.timeScale = 0;
    }


    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

}
