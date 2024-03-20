using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Question : SqlManager
{
    public string question;
    
    public string answer_a;
    public string answer_b;
    public string answer_c;
    public string answer_d;

    public string correctAnswer;

    private int randomID;

    public Question()
    {
        GetRandromQuestionID();
        SetQuestion();
        SetAnswers();
    }


    public void SetQuestion()
    {
        var _query = "SELECT question FROM Questions WHERE question_id = '" + randomID+ "'";
        question = GetInfo(_query, "question");
    }
    
    public void SetAnswers()
    {
        var _queryA = "SELECT answer_a FROM Questions WHERE question_id = '" + randomID+ "'";
        answer_a = GetInfo(_queryA, "answer_a");
        
        var _queryB = "SELECT answer_b FROM Questions WHERE question_id = '" + randomID+ "'";
        answer_b = GetInfo(_queryB, "answer_b");
        
        var _queryC = "SELECT answer_c FROM Questions WHERE question_id = '" + randomID+ "'";
        answer_c = GetInfo(_queryC, "answer_c");
        
        var _queryD = "SELECT answer_d FROM Questions WHERE question_id = '" + randomID+ "'";
        answer_d = GetInfo(_queryD, "answer_d");
        
        var _query = "SELECT correct_answer FROM Questions WHERE question_id = '" + randomID+ "'";
        correctAnswer = GetInfo(_query, "correct_answer");
    }


    public void GetRandromQuestionID()
    {
        var questionAmountQuery = "SELECT COUNT(*) FROM Questions";
        var questionAmount = int.Parse(GetInfo(questionAmountQuery, "COUNT(*)"));

        var randomId = Random.Range(1, (questionAmount+1));
        randomID = randomId;
    }
}
