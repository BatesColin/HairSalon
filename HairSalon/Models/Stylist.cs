using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Stylist.Models
{
  public class Stylist
  {
    private int _stylistId;
    private string _stylistName;

    public Stylist(string StylistName, int StylistId = 0)
    {
      _stylistId = StylistId;
      _stylistName = StylistName;
    }
    public int GetStylistId()
    {
      return _stylistId;
    }
    public string GetStylistName()
    {
      return _stylistName;
    }
    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool descriptionEquality = (this.GetDescription() == newStylist.GetDescription());
        return (idEquality && descriptionEquality);
      }
    }
    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool descriptionEquality = (this.GetDescription() == newStylist.GetDescription());
        return (idEquality && descriptionEquality);
      }
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public int GetId()
    {
      return _id;
    }
    public void Save()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"INSERT INTO `Stylists` (`name`) VALUES (@name);";

     MySqlParameter description = new MySqlParameter();
     description.ParameterName = "@name";
     description.Value = this._name;
     cmd.Parameters.Add(description);

     cmd.ExecuteNonQuery();
     _id = (int) cmd.LastInsertedId;    // This line is new!

     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
   }
   public static List<Stylist> GetAll()
    {
      // return _instances;
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Stylist newStylist = new Stylist(itemDescription, itemId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }


  }
}
