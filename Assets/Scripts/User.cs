using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.MemoryProfiler;
using UnityEngine;

public class User : Item
{ 
    public string username { get;}
    protected int coinAmount;
    protected int gemAmount;
   // protected int knowledgePercentage;
   public int correctAnswers =0;
    public int totalAnswers=0;
    

    public User()
    {
        correctAnswers = int.Parse(GetInfo(GetCorrectAnswersQuery(GetUserIdFromDB()), "correct_answers"));
        totalAnswers = int.Parse(GetInfo(GetTotalAnswersQuery(GetUserIdFromDB()), "total_answers"));
        SetAnswersAndKnowladgePercentage(correctAnswers, totalAnswers);
        // Set username from database 
        PlayerPrefs.SetInt("correctAnswers",correctAnswers);
        PlayerPrefs.SetInt("totalAnswers",totalAnswers);
        
        username = GetInfo(UsernameQuery(), "username");
        
        // if coinAmount is not defined then Init Item (first time)
        if (!PlayerPrefs.HasKey("coinAmount"))
        {
            InitilazeItemForUser();
        }
       
       
    }
    
     
    public void SetAnswersAndKnowladgePercentage(int correctAnswers, int totalAnswers)
    {
        this.correctAnswers = correctAnswers;
        this.totalAnswers = totalAnswers;
        SendInfo(SetTotalAnswersQuery(GetUserIdFromDB(),totalAnswers));
        SendInfo(SetCorrectAnswersQuery(GetUserIdFromDB(),correctAnswers));
        var np = CalculatePercentage();
        SetKnowledgePercentage(np);
    }

    private int CalculatePercentage()
    {
        var percentage = ((float)correctAnswers / (float)totalAnswers) * 100;

        return (int)percentage;
    }

    public void SetKnowledgePercentage(int knowledgePercentage)
    {
        SendInfo(UpdateKnowladgePercentageQuery(knowledgePercentage));
      //  this.knowledgePercentage = int.Parse(GetInfo(GetCityKnowladgePercentageQuery(this.gameObject.name), "knowledgePercentage"));
    }
    
    

    

    

    

 



}
