using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameUI : MonoBehaviour
{

    public UnityAction OnRestartClick;
    
    public TMP_Text playerHealthText;
    public UIPanel gameOverPanel, gameCompletePanel;


    public void UpdatePlayerHealth(int health)
    {
        playerHealthText.text = "Здоровье: " + health.ToString();
    }

    public void OnRestartButtonClick()
    {
        OnRestartClick?.Invoke();
    }

}
