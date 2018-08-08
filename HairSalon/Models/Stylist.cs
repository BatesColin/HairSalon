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
        bool idEquality = (this.GetId() == newStylist.GetStylistId());
        bool nameEquality = (this.GetStylistName() == newStylist.GetStylistName());
        return (idEquality && nameEquality);
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
        bool nameEquality = (this.GetName() == newStylist.GetName());
        return (idEquality && nameEquality);
      }
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
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

     MySqlParameter name = new MySqlParameter();
     name.ParameterName = "@name";
     name.Value = this._name;
     cmd.Parameters.Add(name);

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
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }
    public static Stylist Find(int id)
   {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"SELECT * FROM stylists WHERE id = @thisId;";
       // more logic will go here!
       MySqlParameter thisId = new MySqlParameter();
         thisId.ParameterName = "@thisId";
         thisId.Value = id;
         cmd.Parameters.Add(thisId);
         var rdr = cmd.ExecuteReader() as MySqlDataReader;
         int stylistId = 0;
         string stylistName = "";

         while (rdr.Read())
         {
             stylistId = rdr.GetInt32(0);
             stylistName = rdr.GetString(1);
         }
         Stylist foundStylist= new Stylist(stylistName, stylistId);

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
          }
          return foundStylist;
   }
   public void Edit(string newName)
     {
       MySqlConnection conn = DB.Connection();
       conn.Open();
       var cmd = conn.CreateCommand() as MySqlCommand;
       cmd.CommandText = @"UPDATE stylists SET name = @newName WHERE id = @searchId;";

       cmd.Parameters.Add(new MySqlParameter("@searchId", _stylistId));
       cmd.Parameters.Add(new MySqlParameter("@newName", newName));

       cmd.ExecuteNonQuery();
       _stylistName = newName;

       conn.Close();
       if (conn != null)
       {
           conn.Dispose();
       }
     }
     public static void DeleteAll()
   {
     MySqlConnection conn = DB.Connection();
     conn.Open();

     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"DELETE FROM stylists; DELETE FROM stylists_specialties WHERE stylist_id = @thisId;";

     cmd.ExecuteNonQuery();

     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
   }

  }
}
