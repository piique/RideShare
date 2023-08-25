using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideShare.Interfaces;

namespace RideShare
{
    public class Equipment : IIdentifiable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Equipment()
        {
            this.Name = "";
        }

        public Equipment(string Name)
        {
            this.Name = Name;
        }

        public Equipment(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
