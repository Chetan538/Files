using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class Stuffclass
    {
        public int itemid { get; set; }
        public string name { get; set; }
        public string descriptions { get; set; }
        public Nullable<int> price { get; set; }
    }
}