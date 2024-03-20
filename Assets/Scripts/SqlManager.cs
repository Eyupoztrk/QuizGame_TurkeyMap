using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;

public class SqlManager : MonoBehaviour, IWrite, IRead, IQuery
{
 //   public static T Instance;
    
    private string _connectionString;
    private MySqlConnection _connection;
    private MySqlCommand _command;
    private MySqlDataReader _reader;
    
    public delegate void Login();
    public event Login OnLogin;

   

    private void Start()
    {
        ConnectDatabase();
    }

    private void Update()
    {
        if (OnLogin != null)
        {
            OnLogin();
            OnLogin = null;
        }
    }

        
    


    protected void ConnectDatabase()
    {
         _connectionString = "datasource=192.168.1.3;port=3306;username=root;password=;database=bilgiyarismasi";
       // _connectionString = "server=sql.freedb.tech;port=3306;username=freedb_softflied;password=$%D@!t%P8r%cykW;database=freedb_bilgi_yarismasi";
        //_connectionString = "server=deneme.cbsiosaigdja.eu-north-1.rds.amazonaws.com;port=3306;username=admin;password=Eyupozturk04;database=bilgiyarismasi";
        //_connectionString = "server=dpz.h.filess.io;user=by_excitement;database=by_excitement;port=3307;password=c57c7c6199b90195f112451101161e3f79053d39";
        //_connectionString = "Server=sql11.freemysqlhosting.net;Database=sql11686410;Uid=sql11686410;Pwd=nx5Phljbwr;Port=3306";
        //_connectionString = "server=dpz.h.filess.io;user=by_excitement;database=by_excitement;port=3307;password=c57c7c6199b90195f112451101161e3f79053d39";
      //  _connectionString = "server=127.0.0.1;uid=root;pwd=root;database=sakila";
        if (_connection == null)
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
           
        }
    }
    

    public void SendInfo(string query)
    {
        ConnectDatabase();
        _command = new MySqlCommand(query, _connection);
        _command.ExecuteNonQuery();
    }

    public string GetInfo(string query,string value)
    {
        ConnectDatabase();
        var info = "";
        _command = new MySqlCommand(query, _connection);

        _reader = _command.ExecuteReader();
       
        while (_reader.Read())
        {
            info = _reader[value].ToString();
        }
        
        
        _reader.Close();
        return info;
    }
    
    public IEnumerable<String> GetColumns(string query,string value)
    {
        ConnectDatabase();
        var info = "";
        _command = new MySqlCommand(query, _connection);
        
        _reader = _command.ExecuteReader();

        while ( _reader.Read())
        {
            info = _reader[value].ToString();
            yield return info;
           
        }
        
        _reader.Close();
        
    }
    
    public int GetUserIdFromDB()
    {
        var _username = PlayerPrefs.GetString("username");
        var _query = "SELECT id FROM users WHERE username = '" + _username + "'";
        var id = GetInfo(_query, "id");

        return Int32.Parse(id);
    }
    
    
    
    public string UpdateCointAmountQuery(int value,int id )
    {
        // ConnectDatabase();
        var _query = "UPDATE Items SET coinAmount = '" + value + "' WHERE userId = '" +id+ "'";
        return _query;
    }
    
    public string UpdateKnowladgePercentageQuery(int value)
    {
        // ConnectDatabase();
        var _query = "UPDATE Items SET knowledgePercentage = '" + value + "' WHERE userId = '" +GetUserIdFromDB() + "'";
        return _query;
    }
    
    public string GetCityAvgKnowladgePercentageQuery(string cityName)
    {
       var _query = "SELECT IFNULL(AVG(i.knowledgePercentage), 0) AS average_knowledgePercentage FROM Items i LEFT JOIN Users u ON i.userId = u.Id WHERE u.city_name = '" + cityName + "'";
        //var _query = "SELECT AVG(i.knowledgePercentage) FROM Items i JOIN Users u ON i.userId = u.Id WHERE u.city_name = '" + cityName + "'";
        return _query;
    }
    public string UpdateCityKnowladgePercentageQuery(string cityName,int value)
    {
        var _query = "UPDATE city SET knowledgePercentage = '" + value.ToString() + "' WHERE name = '" + cityName + "'";
        return _query;
    }

    
    
    public string GetCityKnowladgePercentageQuery(string cityName)
    {
        // ConnectDatabase();
        var _query = "SELECT knowledgePercentage FROM city WHERE name = '" +cityName + "'";
        return _query;
    }
    
    public string GetCityNameQuery(int id)
    {
        // ConnectDatabase();
        var _query = "SELECT name FROM city WHERE id = '" +id + "'";
        return _query;
    }
    
    public string GetCoinAmountQuery(int id )
    {
        // ConnectDatabase();
        var _query = "SELECT coinAmount FROM Items WHERE userId = '" + GetUserIdFromDB() + "'";
        return _query;
    } 
    
    public string GetCorrectAnswersQuery(int id)
    {
        var _query = "SELECT correct_answers FROM users WHERE id = '" + GetUserIdFromDB() + "'";
        return _query;
    } 
    
    public string GetTotalAnswersQuery(int id)
    {
        var _query = "SELECT total_answers FROM users WHERE id = '" + GetUserIdFromDB() + "'";
        return _query;
    } 
    
    public string SetCorrectAnswersQuery(int id, int value)
    {
        var _query = "UPDATE users SET correct_answers = '" + value + "' WHERE id = '" + GetUserIdFromDB() + "'";
        return _query;
    } 
    
    public string SetTotalAnswersQuery(int id, int value)
    {
        var _query = "UPDATE users SET total_answers = '" + value + "' WHERE id = '" + GetUserIdFromDB() + "'";
        return _query;
    }

    public string GetLeadersQuery()
    {
        var _query = "SELECT u.username FROM users u JOIN Items i ON u.id = i.userId ORDER BY i.knowledgePercentage DESC ";

        return _query;
    } 
    
    public string GetCityKnowladgePercentageForBoardQuery()
    {
        // ConnectDatabase();
        var _query = "SELECT knowledgePercentage FROM city ORDER BY id";
        return _query;
    }
    
    public string GetCityUserAmountQuery()
    {
        // ConnectDatabase();
        
        //var _query = "SELECT IFNULL(COUNT(u.id), 0) AS user_count FROM City c LEFT JOIN Users u ON c.name= u.city_name GROUP BY c.name";
        var _query = "SELECT IFNULL(COUNT(u.id), 0) AS user_count FROM City c LEFT JOIN Users u ON c.name = u.city_name GROUP BY c.name ORDER BY c.id";
        return _query;
    }
    
    public string GetUserRankQuery()
    {
        var _query = "SELECT u.username FROM users u JOIN Items i ON u.id = i.userId ORDER BY i.knowledgePercentage DESC ";

        return _query;
    } 
    public string GetUserCityNameQuery(int id)
    {
        // ConnectDatabase();
        var _query = "SELECT city_name FROM users WHERE id = '" +id + "'";
        return _query;
    }
    
    public string GetUsernamesQuery()
    {
        // ConnectDatabase();
        var _query = "SELECT username FROM users";
        return _query;
    }
    
    
    
    
    
    
    
}
