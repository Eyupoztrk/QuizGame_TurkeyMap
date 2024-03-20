using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.MemoryProfiler;
using UnityEngine;


public class Item : SqlManager, IQuery
{

    /// <summary>
    ///  Initilaze Items (Coin, Gem and Knowledge Percentage) and add into Database
    /// </summary>
    public void InitilazeItemForUser()
    {
        PlayerPrefs.SetInt("coinAmount",250);
        PlayerPrefs.SetInt("gemAmount",50);
        PlayerPrefs.SetInt("knowledgePercentage",0);
        
        var _query = "INSERT INTO Items (userId, coinAmount, gemAmount, knowledgePercentage) VALUES ('" + GetUserIdFromDB() +
                     "', 250, 50,0)";
        SendInfo(_query);
    }


    public string UsernameQuery()
    {
        // get username from Database to use for User Class set username
        var _username = PlayerPrefs.GetString("username");
        var _query = "SELECT username FROM users WHERE username = '" + _username + "'";
        return _query;
    }
    

    public void SetCoinAmount(int value)
    {
        // ConnectDatabase();
        var _query = "UPDATE Items SET coinAmount = '" + value + "' WHERE userId = '" +GetUserIdFromDB() + "'";
        SendInfo(_query);
    }
    
    public int GetCoinAmount()
    {
        // ConnectDatabase();
        //var _query = "SELECT coinAmount FROM Items WHERE userId = '" + GetUserIdFromDB() + "'";
        var _query = GetCoinAmountQuery(GetUserIdFromDB());
        return int.Parse(GetInfo(_query,"coinAmount"));
    }

    

    public void SetKnowledgePercentage(int value)
    {
        // ConnectDatabase();
        var _query = "UPDATE Items SET knowledgePercentage = '" + value + "' WHERE userId = '" +GetUserIdFromDB() + "'";
        SendInfo(_query);
    }
    
    public int GetKnowledgePercentage()
    {
        // ConnectDatabase();
        var _query = "SELECT knowledgePercentage FROM Items WHERE userId = '" + GetUserIdFromDB() + "'";
        return Int32.Parse(GetInfo(_query,"knowledgePercentage"));
    } 
    
    public void SetGemAmount(int value)
    {
        // ConnectDatabase();
        var _query = "UPDATE Items SET gemAmount = '" + value + "' WHERE userId = '" +GetUserIdFromDB() + "'";
        SendInfo(_query);
    }
    
    public int GetgemAmount()
    {
        // ConnectDatabase();
        var _query = "SELECT gemAmount FROM Items WHERE userId = '" + GetUserIdFromDB() + "'";
        return Int32.Parse(GetInfo(_query,"gemAmount"));
    }

    public int GetUserIdFromDB()
    {
        var _username = PlayerPrefs.GetString("username");
        var _query = "SELECT id FROM users WHERE username = '" + _username + "'";
        var id = GetInfo(_query, "id");

        return Int32.Parse(id);
    }
    public string GetUserCityFromDB()
    {
        var _username = PlayerPrefs.GetString("username");
        var _query = "SELECT city_code FROM users WHERE username = '" + _username + "'";
        var city_code = GetInfo(_query, "city_code");

        return city_code;
    } 
    
        
    
}
