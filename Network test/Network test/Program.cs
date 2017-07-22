using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Network_test
{
    class Program
    {
        private TcpListener listener;


        public Socket open()
        {
            IPAddress ipAd = IPAddress.Parse("129.25.216.186");

            /* Initializes the Listener */
            listener = new TcpListener(ipAd, 8001);
            /* Start Listeneting at the specified port */
            listener.Start();

            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is  :" +
                              listener.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");
            Socket s = listener.AcceptSocket();
            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

            return s;
        }


        public static void Main()
        { }


        public void read()
        {
            Socket s = open();



            byte[] b = new byte[1024];

            while (true)
            {
                int k = s.Receive(b);
                Console.WriteLine("Recieved...");
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));

                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
            }

            /* clean up */
            s.Close();
            listener.Stop();

            //         }
            //         catch (Exception e)
            //        {
            //              Console.WriteLine("Error..... " + e.StackTrace);
            //        }
            Console.ReadLine();

        }
    }
}
