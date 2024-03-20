using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UserInfoBoard : SqlManager
{
    [SerializeField] private int leadersAmount;
    [SerializeField] private List<TextMeshProUGUI> leadersText;
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI cityText;
    [SerializeField] private TextMeshProUGUI totalAnswerText;
    [SerializeField] private TextMeshProUGUI correctAnswerText;
    [SerializeField] private TextMeshProUGUI rankingText;

    private void Start()
    {
        SetUserInfo();
    }


    public void SetUserInfo()
    {
        usernameText.text = PlayerPrefs.GetString("username");
        cityText.text = GetInfo(GetUserCityNameQuery(GetUserIdFromDB()), "city_name");
        correctAnswerText.text = GetInfo(GetCorrectAnswersQuery(GetUserIdFromDB()), "correct_answers");
        totalAnswerText.text = GetInfo(GetTotalAnswersQuery(GetUserIdFromDB()), "total_answers");
        

    
    }
}
