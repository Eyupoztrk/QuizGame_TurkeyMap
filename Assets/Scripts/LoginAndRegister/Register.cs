using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Register : SqlManager
{
    [Header("REGISTER UI")] 
    [SerializeField] private InputField usernameIF;
    [SerializeField] private InputField passwordIF;
    [SerializeField] private string cityname;
    [SerializeField] private TextMeshProUGUI errorMessage;

    private string _username;
    private string _password;
    private string _cityName;

    private string _query;

    public void GetCity(int index)
    {
        string[] cityNamesByPlate = {
        "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
        "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
        "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
        "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir",
        "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir",
        "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon",
        "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale",
        "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
    };

        cityname = cityNamesByPlate[index];
        
        print(cityname + " " + index);


    }




    public void RegisterUser()
    {
        PlayerPrefs.DeleteAll();
        SetInputs();
        _query = "INSERT INTO users (username, password, city_name,correct_answers,total_answers) VALUES ('" + _username + "', '" + _password + "', '" + _cityName + "', '" + 0+ "', '" + 0+ "')";

        if (CanRegister(_username,_password))
        {
            SendInfo(_query);
            OpenLoginPanel();
        }
        
    }

    public void OpenLoginPanel()
    {
        errorMessage.text = "";
        UIManager.Instance.CloseAndOpenPanel(UIManager.Instance.registerPanel,UIManager.Instance.loginPanel);
    }

    public bool CanRegister(string username,string password)
    {
        if (username.Equals("") || password.Equals(""))
        {
            print("kullanici adı veya şifre boş olamaz");
            errorMessage.text = "Kullanici adı veya şifre boş olamaz";
            return false;
        }
          

        var usernames = GetColumns(GetUsernamesQuery(), "username").ToList();
        if (usernames.Contains(username))
        {
            print("aynı kullanıcı adı var");
            errorMessage.text = "Aynı kullanıcı adı var";
            return false;
        }
            

        return true;
    }

    public void SetInputs()
    {
        _username = usernameIF.text;
        _password = passwordIF.text;
        _cityName = cityname;
    }
}
