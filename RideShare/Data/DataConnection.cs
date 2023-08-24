//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using RideShare.Interfaces;
using System.Text.Json;
using System.Xml.Linq;
//using System.Threading.Tasks;

namespace RideShare.Data
{
    class DataConnection<T> where T : IIdentifiable
    {
        private DataStore<T> dataStore = new DataStore<T>();


        private string path = Path.Combine(Environment.CurrentDirectory, $@"..\..\..\Data\{typeof(T).Name}.json");

        public DataConnection() 
        {
            if (File.Exists(path))
            {
                var jsonString = File.ReadAllText(path);

                if (!string.IsNullOrEmpty(jsonString))
                {
                    dataStore = JsonSerializer.Deserialize<DataStore<T>>(jsonString) ?? new DataStore<T>();
                    Console.WriteLine(JsonSerializer.Serialize(dataStore));
                }
            }
            else
            {
                dataStore.Items = new List<T>();
            }
        }

        public bool AddNewItem(T item)
        {
            try
            {
                dataStore.LastInsertedId++;
                dataStore.TotalItems++;
                item.Id = dataStore.LastInsertedId;
                dataStore.Items.Add(item);
                SaveDataStoreToFile();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                return false;
            }
        }

        private void SaveDataStoreToFile()
        {
            string json = JsonSerializer.Serialize(dataStore);
            File.WriteAllText(path, json);
        }
    }

}
