using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideShare.Interfaces;

namespace RideShare
{
    public class EquipmentType : IIdentifiable
    {
        private int _id;
        private string _name = string.Empty;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 5) throw new ArgumentException("Name must be at least 5 characters long");
                _name = value;
            }
        }

        public EquipmentType(string name)
        {
            Name = name;
        }

        public EquipmentType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}