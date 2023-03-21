using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI RocketHealth;
    public int rocketHealthCount;

    private void Start()
    {
        rocketHealthCount = 6;
        RocketHealthUpdate();
    }

    public void RocketHealthUpdate()
    {
        RocketHealth.text = rocketHealthCount.ToString();
    }
}
