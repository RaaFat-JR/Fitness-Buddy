using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessBuddy.Models
{
    public class Member : Person
    {
        public Trainer Trainer { get; set; }
    }
}