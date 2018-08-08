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

}
}
