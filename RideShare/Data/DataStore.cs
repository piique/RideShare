using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideShare.Data
{
    class DataStore<T>
    {
        public int LastInsertedId { get; set; }
        public int TotalItems { get; set; }

        public List<T> Items { get; set; } = new List<T>();

        public DataStore() { 
            LastInsertedId = 0;
            TotalItems = 0;
            Items = new List<T>();
        }
    }
}
