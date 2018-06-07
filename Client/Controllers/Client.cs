using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CoincheCardGame.Controllers
{
    public class Client
    {
        private static Thread _thEcoute;
        private static int port;
        private static UdpClient server;
        
        private static void Main(string[] args)
        {
            server = new UdpClient(0,AddressFamily.InterNetwork);
            port = ((IPEndPoint) server.Client.LocalEndPoint).Port;
            _thEcoute = new Thread(listen);
            _thEcoute.Start();
            Console.Write("Please enter your name : ");
            string name;
            name = Console.ReadLine();
            sendMessage("log"+name);
        }

        private static void sendMessage(string message)
        {
            //Sérialisation du message en tableau de bytes.
            byte[] msg = Encoding.Default.GetBytes(message);
            //La méthode Send envoie un message UDP.
            server.Send(msg, msg.Length, "127.0.0.1", 5000);
        }
        
        private static void listen()
        {
            //On crée le client en lui spécifiant le port sur lequel il devra écouter.
            //UdpClient client = new UdpClient(port);
            //Création d'une boucle infinie qui aura pour tâche d'écouter.
            while (true)
            {
                //Création d'un objet IPEndPoint qui recevra les données du Socket distant.
                IPEndPoint serveur = null;
                //On écoute jusqu'à recevoir un message.
                byte[] data = server.Receive(ref serveur);
                //Décryptage et affichage du message.
                string message = Encoding.Default.GetString(data);
                Console.WriteLine("{0}\n", message);
            }
        }
    }
}