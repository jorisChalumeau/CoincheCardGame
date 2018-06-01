using System;
using System.Net.Sockets;
using System.Text;

namespace CoincheCardGame.Controllers
{
    public class Client
    {
        private static void Main(string[] args)
        {
            
        }

        private void sendMessage(string message)
        {
            //Sérialisation du message en tableau de bytes.
            byte[] msg = Encoding.Default.GetBytes(message);

            UdpClient udpClient = new UdpClient();

            //La méthode Send envoie un message UDP.
            udpClient.Send(msg, msg.Length, "127.0.0.1", 5000);

            udpClient.Close();
        }
    }
}