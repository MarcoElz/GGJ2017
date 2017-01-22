using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
   
    public static UIManager instance;

    public Image healthBar;
    public Text score;

    void Start()
    {
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
        score.text = actualScore.ToString();
    }

}
