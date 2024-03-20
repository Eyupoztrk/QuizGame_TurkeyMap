using System.Collections.Generic;
using MySql.Data.MySqlClient;

public interface IRead 
{
  public string GetInfo(string query,string value);
}