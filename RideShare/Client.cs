using RideShare.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare
{
    public class Client : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Client()
        {
            this.Name = "";
        }

        public Client(string Name)
        {
            this.Name = Name;
        }

        public Client(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

    }
}
