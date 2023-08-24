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

            DataConnection<Client> connection = new Data.DataConnection<Client>();
            List<Client> clients = new List<Client>();
        }
    }
}