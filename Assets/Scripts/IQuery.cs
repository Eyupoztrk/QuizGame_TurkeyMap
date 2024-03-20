using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuery
{
    public string UpdateCointAmountQuery(int value, int id);
    public string GetCoinAmountQuery(int id);

}
