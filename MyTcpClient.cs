using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace Klient
{
    public class MyTcpClient
    {
        Int32 port=0;
        string server = string.Empty;
        public MyTcpClient(String server, Int32 port)
        {
            this.server = server;
            this.port = port;
        }
        public void ConnectAndReceive()
        {
            try
            {
                string path = @"C:\Users\Dawid\Desktop\Studia\ProjektServerKlient\Receive\Profile.png";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                //TcpClient zgodnie z tym co podano w konsoli
                Console.WriteLine("Próba połączenia z {0}:{1}", server, port);
                TcpClient client = new TcpClient(this.server, this.port);
                NetworkStream stream = client.GetStream();
                if(stream != null) 
                {
                    using (FileStream fs = File.Create(path))
                    {
                        Console.WriteLine("Zapis pliku:{0}", path);
                        stream.CopyTo(fs);
                    }
                }
                Console.WriteLine("Zakończono zapis");


                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                TryAgain();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("FileNotFoundException: {0}", e);
                TryAgain();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
                TryAgain();
            }
            Console.Read();
        }
        public void TryAgain()
        {
            Console.WriteLine("###############\nSpróbować ponownie? tak[t/T], zmien dane serwera[z/Z], nie[cokolwiek innego]");
            string ans =Console.ReadLine();
            if (ans=="t" || ans=="T") {
                
                ConnectAndReceive();
            }
            else if (ans=="z" || ans=="Z")
            {
                Console.WriteLine("Podaj ip address serwera");
                this.server = Console.ReadLine();
                Console.WriteLine("Podaj port serwera");
                this.port = Int32.Parse(Console.ReadLine());
                ConnectAndReceive();
            }
            else
            {
                Console.WriteLine("Naciśnij cokolwiek by zamknąć okno");
            }
        }
    }
}

