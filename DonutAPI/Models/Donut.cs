using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonutAPI.Models
{
    public class Card
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public string Extras { get; set; }
        public string Image { get; set; }
    }
}