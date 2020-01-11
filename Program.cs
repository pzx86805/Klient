using System;


namespace Klient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj ip address serwera");
            string serverAddress = Console.ReadLine();
            Console.WriteLine("Podaj port serwera");
            Int32 port = Int32.Parse(Console.ReadLine());

            //Tworzę klienta sieciowego
            MyTcpClient client = new MyTcpClient(serverAddress, port);
            client.ConnectAndReceive();
        }
    }
}
