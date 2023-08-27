using RideShare.Data;
using System.Xml.Linq;

namespace RideShare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Pedro");

            var dataConnection = new DataConnection<Client>();

            dataConnection.AddNewItem(client);
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
                Console.WriteLine("3 - Equipment Types");
                Console.WriteLine("4 - Exit");
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
                        EquipmentTypeMenu();
                        break;
                    case "4":
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
            DataConnection<Equipment> connectionEquipment = new Data.DataConnection<Equipment>();
            DataConnection<EquipmentType> connectionEquipmentType = new Data.DataConnection<EquipmentType>();
            List<Equipment> equipments = new List<Equipment>();
            List<EquipmentType> equipmentsTypes = new List<EquipmentType>();
            string? option;
            string? id;
            string? name;
            Equipment? equipment;
            EquipmentType? equipmentType;

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
                        equipmentsTypes = connectionEquipmentType.GetAllItems();
                        foreach (var _equipmentType in equipmentsTypes)
                        {
                            Console.WriteLine($"{_equipmentType.Id} - {_equipmentType.Name}");
                        }
                        Console.Write("\nChoose an equipment type: ");
                        id = Console.ReadLine();
                        if (id == null || id == "")
                        {
                            Console.WriteLine("Invalid ID");
                            Console.WriteLine("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        equipmentType = connectionEquipmentType.GetItemById(int.Parse(id));
                        if (equipmentType == null)
                        {
                            Console.WriteLine("Invalid equipment type");
                            Console.WriteLine("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        var newEquipment = new Equipment(name, equipmentType);
                        connectionEquipment.AddNewItem(newEquipment);
                        Console.WriteLine("Equipment added successfully!");
                        Console.WriteLine("\nPress any key to back to menu...");
                        break;
                    case "2":
                        Console.Clear();
                        equipments = connectionEquipment.GetAllItems();
                        foreach (var _equipment in equipments)
                        {
                            Console.WriteLine($"{_equipment.Id} - {_equipment.Description}");
                        }
                        Console.WriteLine("\nPress any key to back to menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        // ID input
                        Console.Write("Type an equipment ID to update: ");
                        id = Console.ReadLine();
                        if (id == null || id == "")
                        {
                            Console.WriteLine("Invalid ID");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }

                        // Name input
                        Console.Write("Type the new name: ");
                        name = Console.ReadLine();
                        if (name == null || name == "")
                        {
                            Console.WriteLine("Invalid name");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }

                        // Equipment Type input
                        equipmentsTypes = connectionEquipmentType.GetAllItems();
                        foreach (var _equipmentType in equipmentsTypes)
                        {
                            Console.WriteLine($"{_equipmentType.Id} - {_equipmentType.Name}");
                        }
                        Console.Write("\nChoose an equipment type: ");
                        id = Console.ReadLine();
                        if (id == null || id == "")
                        {
                            Console.WriteLine("Invalid ID");
                            Console.WriteLine("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        equipmentType = connectionEquipmentType.GetItemById(int.Parse(id));
                        if (equipmentType == null)
                        {
                            Console.WriteLine("Invalid equipment type");
                            Console.WriteLine("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        equipment = new Equipment(int.Parse(id), name, equipmentType);
                        connectionEquipment.UpdateItem(equipment);
                        Console.WriteLine($"Equipment {id} - {name} updated successfully!");
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
                        connectionEquipment.RemoveItem(int.Parse(id));
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

        static void EquipmentTypeMenu()
        {
            DataConnection<EquipmentType> connection = new Data.DataConnection<EquipmentType>();
            List<EquipmentType> equipmentTypes = new List<EquipmentType>();
            EquipmentType? equipmentType;
            string? option;
            string? id;
            string? name;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Create new equipment type");
                Console.WriteLine("2 - Read all equipment types");
                Console.WriteLine("3 - Update equipment type");
                Console.WriteLine("4 - Delete equipment type");
                Console.WriteLine("5 - Back to main menu");
                Console.Write("\nChoose an option: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Enter the equipment type name:");
                        name = Console.ReadLine();
                        if (name == null || name == "")
                        {
                            Console.WriteLine("Invalid name");
                            Console.WriteLine("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        var newEquipmentType = new EquipmentType(name);
                        connection.AddNewItem(newEquipmentType);
                        Console.WriteLine("Equipment type added successfully!");
                        Console.WriteLine("\nPress any key to back to menu...");
                        break;
                    case "2":
                        Console.Clear();
                        equipmentTypes = connection.GetAllItems();
                        foreach (var _equipmentType in equipmentTypes)
                        {
                            Console.WriteLine($"{_equipmentType.Id} - {_equipmentType.Name}");
                        }
                        Console.WriteLine("\nPress any key to back to menu...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Type an equipment type ID to update: ");
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
                        equipmentType = new EquipmentType(int.Parse(id), name);
                        connection.UpdateItem(equipmentType);
                        Console.WriteLine($"Equipment type {id} updated successfully!");
                        Console.Write("\nPress any key to back to menu...");
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Type an equipment type ID to delete: ");
                        id = Console.ReadLine();
                        if (id == null || id == "")
                        {
                            Console.WriteLine("Invalid ID");
                            Console.Write("\nPress any key to back to menu...");
                            Console.ReadKey();
                            break;
                        }
                        connection.RemoveItem(int.Parse(id));
                        Console.WriteLine($"Equipment type {id} deleted successfully!");
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
