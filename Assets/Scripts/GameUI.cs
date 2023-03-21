using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static GameUI UIInstance;
    public GameObject GameoverUI;
    public TextMeshProUGUI RocketHealth, GameScoreDisplay;
    private int rocketHealthCount, GameScore;

    private void Start()
    {
        UIInstance = this;
        Time.timeScale = 1;
        rocketHealthCount = 2;
        GameScore = 0;
        RocketHealth.text = rocketHealthCount.ToString();
    }
    public void RocketHealthUpdate()
    {
        rocketHealthCount--;
        if(rocketHealthCount == 0)
        {
            Time.timeScale = 0;
            GameoverUI.SetActive(true);
        }
        RocketHealth.text = rocketHealthCount.ToString();
    }
    public void ScoreUpdate()
    {
        GameScore += 2;
        GameScoreDisplay.text = GameScore.ToString();
    }
    public void GameRestart(int count)
    {
        SceneManager.LoadScene(count);
    }
}
