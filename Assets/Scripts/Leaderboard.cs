using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Leaderboard : SqlManager
{
   [SerializeField] private int leadersAmount;
   [SerializeField] private List<TextMeshProUGUI> leadersText;

   private void Start()
   {
       SetLeaders();
       
   }


   public void SetLeaders()
    {
        for (int i = 0; i < leadersAmount; i++)
        {
            var columns = GetColumns(GetLeadersQuery(), "username").ToList();
            if(columns.Count > 0)
            {
                leadersText[i].text = (i +1) +" - "+ columns[i];
            }
        }

        
        
    }
}
