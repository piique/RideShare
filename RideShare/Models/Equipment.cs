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
        private int _id;
        private string _description = string.Empty;

        private EquipmentType _type;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value.Length < 5) throw new ArgumentException("Description must be at least 5 characters long");
                _description = value;
            }
        }

        public EquipmentType Type
        {
            get { return _type; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "Type cannot be null.");
                _type = value;
            }
        }

        public Equipment(string description, EquipmentType type)
        {
            Description = description;
            Type = type;
        }

        public Equipment(int id, string description, EquipmentType type)
        {
            Id = id;
            Description = description;
            Type = type;
        }
    }
}