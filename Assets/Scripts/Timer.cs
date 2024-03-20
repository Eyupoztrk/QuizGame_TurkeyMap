using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;
    public float totalTime = 120; // Toplam süre, saniye cinsinden

    private float timeRemaining;

    private void Start()
    {
        timeRemaining = totalTime;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1;
            UpdateTimerDisplay();
        }
        
        // Zaman dolduğunda yapılacak işlemler buraya gelebilir
        Debug.Log("Zaman doldu!");
    }

    void UpdateTimerDisplay()
    {
        timeSlider.value = (totalTime - timeRemaining) / totalTime;
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        QuizManager.instance.timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}