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


        private string path = Path.Combine(Environment.CurrentDirectory, $@"Data\{typeof(T).Name}.json");

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

        public T? GetItemById(int id)
        {
            try
            {
                return dataStore.Items.FirstOrDefault(i => i.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                return default;
            }
        }

        public int AddNewItem(T item)
        {
            try
            {
                dataStore.LastInsertedId++;
                dataStore.TotalItems++;
                item.Id = dataStore.LastInsertedId;
                dataStore.Items.Add(item);
                SaveDataStoreToFile();

                return item.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                return -1;
            }
        }

        public T? RemoveItem(int itemId)
        {
            try
            {
                var item = dataStore.Items.FirstOrDefault(i => i.Id == itemId);
                if (item != null)
                {
                    dataStore.Items.Remove(item);
                    SaveDataStoreToFile();
                    return item;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                return default;
            }
        }

        public T? UpdateItem(T item)
        {
            try
            {
                int index = dataStore.Items.FindIndex(i => i.Id == item.Id);
                if (index != -1)
                {
                    dataStore.Items[index] = item;
                    SaveDataStoreToFile();
                    return item;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                return default;
            }
        }

        public List<T> GetAllItems()
        {
            return dataStore.Items;
        }

        private void SaveDataStoreToFile()
        {
            string json = JsonSerializer.Serialize(dataStore);
            File.WriteAllText(path, json);
        }
    }

}
