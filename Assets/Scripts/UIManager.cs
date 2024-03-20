using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject leaderboardPanel;
    public GameObject cityBoardPanel;
    public GameObject userInfoBoard;

    public TextMeshProUGUI _usernameText;
    public TextMeshProUGUI _coinAmountText;
    public TextMeshProUGUI _getAmountText;
    public TextMeshProUGUI _knowledgePercentageText;


    private void Awake()
    {
        Instance = this;
    }

    public void CloseAndOpenPanel(GameObject panel1, GameObject panel2)
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void SetText(TextMeshProUGUI text, string value)
    {
        text.text = value;
    }
    
    
}
