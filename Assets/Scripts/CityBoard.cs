using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CityBoard : SqlManager
{
    [SerializeField] private List<GameObject> cityBoards;
    [SerializeField] private int cityAmount;
    [SerializeField] private List<TextMeshProUGUI> cityText;

    private void Start()
    {
        print("girdi");
        SetCityBoard();
       
    }


    public void SetCityBoard()
    {
        for (int i = 0; i < cityAmount; i++)
        {
            var cityName = GetInfo(GetCityNameQuery(i+1),"name");
            var cityUserAmounts = GetColumns(GetCityUserAmountQuery(),"user_count").ToList();
            var columns = GetColumns(GetCityKnowladgePercentageForBoardQuery(), "knowledgePercentage").ToList();
            if(columns.Count > 0)
            {
                cityText[i].text = cityName.ToUpper() +" % "+ columns[i] +"\n bu şehirde " + cityUserAmounts[i] +" kişi oynuyor";
            }
        }

        
        
    }
    
    
    
}
