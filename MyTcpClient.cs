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
                TcpClient client = new TcpClient(this.server, this.port);
                NetworkStream stream = client.GetStream();
                if(stream != null) {
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
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("FileNotFoundException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}

