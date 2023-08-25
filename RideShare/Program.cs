using RideShare.Data;
using System.Xml.Linq;

namespace RideShare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Client client = new Client("Pedro");

            // var dataConnection = new DataConnection<Client>();
            // dataConnection.AddNewItem(client);
            MainMenu();

        }

        static void MainMenu()
        {
            string? option;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Clients");
                Console.WriteLine("2 - Equipments");
                Console.WriteLine("3 - Exit");
                Console.Write("\nChoose an option: ");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ClientMenu();
                        break;
                    case "2":
                        EquipmentMenu();
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void ClientMenu()
        {
            DataConnection<Client> connection = new Data.DataConnection<Client>();
            List<Client> clients = new List<Client>();
            Client? client;
            string? option;
            string? id;
            string? name;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Create new client");
                Console.WriteLine("2 - Read all clients");
                Console.WriteLine("3 - Update Client");
                Console.WriteLine("4 - Delete Cliente");
                Console.WriteLine("5 - Back to main menu");
                Console.Write("\nChoose an option: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Enter the client name:");
                        name = Console.ReadLine();
                        if (name == null || name == "")
                        {
                            Console.WriteLine("Invalid name");
                            Console.WriteLine("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        var newClient = new Client(name);
                        connection.AddNewItem(newClient);
                        Console.WriteLine("Client added successfully!");
                        Console.WriteLine("\nPress any key to back to menu...");
                        break;
                    case "2":
                        Console.Clear();
                        clients = connection.GetAllItems();
                        foreach (var _client in clients)
                        {
                            Console.WriteLine($"{_client.Id} - {_client.Name}");
                        }
                        Console.WriteLine("\nPress any key to back to menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Type an client ID to update: ");
                        id = Console.ReadLine();
                        if (id == null || id == "")
                        {
                            Console.WriteLine("Invalid ID");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Type the new name: ");
                        name = Console.ReadLine();
                        if (name == null || name == "")
                        {
                            Console.WriteLine("Invalid name");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        client = new Client(int.Parse(id), name);
                        connection.UpdateItem(client);
                        Console.WriteLine($"Client {id} updated successfully!");
                        Console.Write("\nPress any key to back to menu...");
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Type an client ID to delete: ");
                        id = Console.ReadLine();
                        if (id == null || id == "")
                        {
                            Console.WriteLine("Invalid ID");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        connection.RemoveItem(int.Parse(id));
                        Console.WriteLine($"Client {id} deleted successfully!");
                        Console.Write("\nPress any key to back to menu...");
                        break;
                    case "5":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void EquipmentMenu()
        {
            DataConnection<Equipment> connection = new Data.DataConnection<Equipment>();
            List<Equipment> equipments = new List<Equipment>();
            Equipment? equipment;
            string? option;
            string? id;
            string? name;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Create new equipment");
                Console.WriteLine("2 - Read all equipments");
                Console.WriteLine("3 - Update equipment");
                Console.WriteLine("4 - Delete equipment");
                Console.WriteLine("5 - Back to main menu");
                Console.Write("\nChoose an option: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Enter the equipment name:");
                        name = Console.ReadLine();
                        if (name == null || name == "")
                        {
                            Console.WriteLine("Invalid name");
                            Console.WriteLine("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        var newEquipment = new Equipment(name);
                        connection.AddNewItem(newEquipment);
                        Console.WriteLine("Equipment added successfully!");
                        Console.WriteLine("\nPress any key to back to menu...");
                        break;
                    case "2":
                        Console.Clear();
                        equipments = connection.GetAllItems();
                        foreach (var _equipment in equipments)
                        {
                            Console.WriteLine($"{_equipment.Id} - {_equipment.Name}");
                        }
                        Console.WriteLine("\nPress any key to back to menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Type an equipment ID to update: ");
                        id = Console.ReadLine();
                        if (id == null || id == "")
                        {
                            Console.WriteLine("Invalid ID");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Type the new name: ");
                        name = Console.ReadLine();
                        if (name == null || name == "")
                        {
                            Console.WriteLine("Invalid name");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        equipment = new Equipment(int.Parse(id), name);
                        connection.UpdateItem(equipment);
                        Console.WriteLine($"Equipment {id} updated successfully!");
                        Console.Write("\nPress any key to back to menu...");
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Type an equipment ID to delete: ");
                        id = Console.ReadLine();
                        if (id == null || id == "")
                        {
                            Console.WriteLine("Invalid ID");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        connection.RemoveItem(int.Parse(id));
                        Console.WriteLine($"Equipment {id} deleted successfully!");
                        Console.Write("\nPress any key to back to menu...");
                        break;
                    case "5":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }


    }
}