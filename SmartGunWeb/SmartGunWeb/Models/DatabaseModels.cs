using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGunWeb.Models
{
    public enum Status
    {
        Ok, Warning, Critical
    }

    public class Policeman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Status status { get; set; }
    }


}