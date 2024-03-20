using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<City> _cities;
    [HideInInspector] public User _user;
    public Leaderboard leaderboard;
    public CityBoard cityBoard;
    public UserInfoBoard userInfoBoard;

    private void Awake()
    {
        Instance = this;
    }
    

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        // Creating new user for game
       
        _user = new User();
        //playerCity = new City(_user.username);
        SetTexts();
        
      //  SetPlayerCity();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateCityColor();
        }
    }

   /* public void SetPlayerCity()
    {
        print(PlayerPrefs.GetString("cityName"));
        foreach (var city in _cities)
        {
            if (city.gameObject.name.Equals(PlayerPrefs.GetString("cityName")))
            {
                //playerCity = city;
            }
        }
    }*/

    public void UpdateCityColor()
    {
        foreach (var city in _cities)
        {
            city.SetKnowledgePercentage();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Scenes/QuizScene", LoadSceneMode.Additive);
    }
    
    public void SetTexts()
    {
        // set UI for User
        UIManager.Instance.SetText(UIManager.Instance._usernameText,_user.username);
        UIManager.Instance.SetText(UIManager.Instance._coinAmountText,_user.GetCoinAmount().ToString());
        UIManager.Instance.SetText(UIManager.Instance._knowledgePercentageText,_user.GetKnowledgePercentage().ToString());
        UIManager.Instance.SetText(UIManager.Instance._getAmountText,_user.GetgemAmount().ToString());
    }

    public void OpenLeaderboardPanel()
    {
        leaderboard.SetLeaders();
       UIManager.Instance.OpenPanel(UIManager.Instance.leaderboardPanel); 
    }
    
    public void CloseLeaderboardPanel()
    {
       UIManager.Instance.ClosePanel(UIManager.Instance.leaderboardPanel); 
    } 
    
    public void OpenCityBoardPanel()
    {
       cityBoard.SetCityBoard();
       UIManager.Instance.OpenPanel(UIManager.Instance.cityBoardPanel); 
    }
    
    public void CloseCityBoardPanel()
    {
       UIManager.Instance.ClosePanel(UIManager.Instance.cityBoardPanel); 
    } 
    
    public void OpenUserInfoBoardPanel()
    {
        userInfoBoard.SetUserInfo();
       UIManager.Instance.OpenPanel(UIManager.Instance.userInfoBoard); 
    }
    
    public void CloseUserInfoBoardPanel()
    {
       UIManager.Instance.ClosePanel(UIManager.Instance.userInfoBoard); 
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("LoginAndRegisterScene");
        PlayerPrefs.DeleteAll();
        
    }










}
