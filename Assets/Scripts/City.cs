using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public class City : SqlManager
{
    public string name;
    private int knowledgePercentage;
    private SpriteRenderer _spriteRenderer;
   

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetKnowledgePercentage();
    }



    public void SetKnowledgePercentage()
    {
        var kp = float.Parse(GetInfo(GetCityAvgKnowladgePercentageQuery(this.gameObject.name), "average_knowledgePercentage"));
        SendInfo(UpdateCityKnowladgePercentageQuery(this.gameObject.name,(int)kp));
        SetColor();

    }
    public int GetKnowledgePercentage()
    {
        var kp = GetInfo(GetCityKnowladgePercentageQuery(this.gameObject.name), "knowledgePercentage");
        return int.Parse(kp);
    }
    
    
    private void SetColor()
    {
        var kp = GetKnowledgePercentage();
        // green
        if (kp >= 65)
        {
            _spriteRenderer.color = hexColor("#65B741");
        }
        // yellow
        else if (kp >= 45 && kp < 65)
        {
            _spriteRenderer.color = hexColor("#fdc500");
        }
        // red
        else if (kp >= 1 && kp < 45)
        {
            _spriteRenderer.color = hexColor("#f94144");
        }
        else
        {
            _spriteRenderer.color = hexColor("#C7C8CC");
        }
    }

    public Color hexColor(string htmlValue)
    {
        Color newCol;

        if (ColorUtility.TryParseHtmlString(htmlValue, out newCol))
        {
            return newCol;
        }
        return Color.black;
    }

}
