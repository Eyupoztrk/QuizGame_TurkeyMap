using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{

    public static QuizManager instance;

    private void Awake()
    {
        instance = this;
    }

    private Question _question;
    private Timer _timer;
    
    [SerializeField] private TextMeshProUGUI question_Text;
    [SerializeField] private TextMeshProUGUI answerA_Text;
    [SerializeField] private TextMeshProUGUI answerB_Text;
    [SerializeField] private TextMeshProUGUI answerC_Text;
    [SerializeField] private TextMeshProUGUI answerD_Text;
    
    public TextMeshProUGUI timerText;
    
    public delegate void Answer();
    public event Answer OnCorrectAnswer;
    public event Answer OnWrongAnswer;
 
    private void Start()
    {
        _question = new Question();
        SetQuiz();
    }
    
    private void Update()
    {
        if (OnCorrectAnswer != null)
        {
            OnCorrectAnswer();
            OnCorrectAnswer = null;
        } 
        
        if (OnWrongAnswer != null)
        {
            OnWrongAnswer();
            OnWrongAnswer = null;
        }
    }

    public void SetQuiz()
    {
        question_Text.text = _question.question;
        answerA_Text.text = _question.answer_a;
        answerB_Text.text = _question.answer_b;
        answerC_Text.text = _question.answer_c;
        answerD_Text.text = _question.answer_d;
    }

    public void ChechAnswer(string answer)
    {
        if (answer.ToLower().Equals(_question.correctAnswer.ToLower()))
        {
            OnCorrectAnswer += CorrectAnswer;
        }
        else
        {
            OnWrongAnswer += WrongAnswer;
        }
    }

    private void CorrectAnswer()
    {
        ++GameManager.Instance._user.correctAnswers;
        ++GameManager.Instance._user.totalAnswers;
        _question = new Question();
        SetQuiz();
    }
    
    private void WrongAnswer()
    {
        ++GameManager.Instance._user.totalAnswers;

        _question = new Question();
        SetQuiz(); 
    }

    public void FinishQuiz()
    {
        var correctAnswers =  GameManager.Instance._user.correctAnswers;
        var totalAnswers = GameManager.Instance._user.totalAnswers;
        
        print(correctAnswers + ", "+ totalAnswers);
        GameManager.Instance._user.SetAnswersAndKnowladgePercentage(correctAnswers,totalAnswers);
    }

    public void ExitQuiz()
    {
        SceneManager.LoadScene("Scenes/MainScene", LoadSceneMode.Single);
    }


}
