using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : SqlManager
{
    [Header("LOGIN UI")] 
    [SerializeField] private InputField usernameIF;
    [SerializeField] private InputField passwordIF;

    private string _username;
    private string _password;
    private string _query;
    
    public void LoginUser()
    {
        var username = "";
        var password = "";
        
        SetInputs();
        _query = "SELECT username, password FROM users WHERE username = '" + _username + "'";
        username =  GetInfo(_query, "username");
        password =  GetInfo(_query, "password");
        

        if (CheckValidate(username, password))
        {
            SaveUsername(username);
            OnLogin += LoginSuccesfull;
           
        }
        else
        {
            LoginUnsuccesfull();
        }
        
    }

    public void SaveUsername(string username)
    {
        PlayerPrefs.SetString("username",username);
    }

    protected void LoginSuccesfull()
    {
        ScenesManager.Instance.OpenSceneSingle("Scenes/MainScene");
    }

    public void OpenRegisterPanel()
    {
        UIManager.Instance.CloseAndOpenPanel(UIManager.Instance.loginPanel,UIManager.Instance.registerPanel);
    }
    protected void LoginUnsuccesfull()
    {
        Debug.Log("Giriş Başarısız oldu..");
    }

    private bool CheckValidate(string username, string password)
    {
        if (username.Equals(_username) && password.Equals(_password))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetInputs()
    {
        _username = usernameIF.text;
        _password = passwordIF.text;
    }
}
